using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Disqussing
{
	public interface IApiKey
	{
		string ParameterName { get; }
		string Value { get; }
	}

	public class PrivateApiKey : IApiKey
	{
		public PrivateApiKey(string key)
		{
			Value = key;
		}

		public string Value { get; private set; }
		public string ParameterName
		{
			get { return "api_secret"; }
		}
	}

	public class PublicApiKey : IApiKey
	{
		public PublicApiKey(string key)
		{
			Value = key;
		}

		public string Value { get; private set; }
		public string ParameterName
		{
			get { return "api_key"; }
		}
	}

    public partial class DisqusClient
    {
		public DisqusClient(IApiKey apiKey, string version, IUrlClient client)
		{
			ApiKey = apiKey;
			UrlClient = client;
			Version = version;
		}

		public IUrlClient UrlClient { get; set; }
		public IApiKey ApiKey { get; set; }
		public string Version { get; set; }

		public Response<T> MakeRequest<T>(string resource, string method, HttpMethod httpMethod, object queryStringArguments)
			where T : new()
		{
			return MakeRequest<T>(resource, method, httpMethod, UrlHelper.ObjectToDictionary(queryStringArguments));
		}

		public Response<T> MakeRequest<T>(string resource, string method, HttpMethod httpMethod, Dictionary<string, string> queryStringArguments)
			 where T : new()
		{
			var httpResponse = GetResponse(resource, method, httpMethod, queryStringArguments);
			return ParseResponse<T>(httpResponse);
		}

		public Response<T> ParseResponse<T>(HttpResponse httpResponse)
			where T : new()
		{
			if (httpResponse == null)
				throw new ArgumentNullException("httpResponse");
			if (httpResponse.Error != null && String.IsNullOrEmpty(httpResponse.Body))
				throw new ApiException("Error retrieving url " + httpResponse.Url);

			Response<T> response = SerializationHelper.DeserializeJson<Response<T>>(httpResponse.Body);
			//if (response.Error != null)
			//	throw new ApiException(response.Error);

			return response;
		}

		public HttpResponse GetResponse(string resource, string method, HttpMethod httpMethod, Dictionary<string, string> queryStringArguments)
		{
			EnsureApiKey(queryStringArguments);
			Uri url = UrlHelper.BuildUrl(Version, resource, method, queryStringArguments);
			return UrlClient.MakeRequest(url, httpMethod);
		}

		protected void EnsureApiKey(IDictionary<string, string> queryStringArguments)
		{
			if (!String.IsNullOrEmpty(ApiKey.Value) && !queryStringArguments.ContainsKey(ApiKey.ParameterName))
			{
				queryStringArguments.Add(ApiKey.ParameterName, ApiKey.Value);
			}
		}
    }

	public partial class DisqusClient
	{
		public User GetUser(UserIdOrName idOrName)
		{
			var response = MakeRequest<User>(Resources.Users, "details", HttpMethod.GET, new Dictionary<string, string>
			{
				{idOrName.GetKey(), idOrName.GetValue()}
			});

			return response.Data;
		}
	}

	public class UserIdOrName
	{
		private int? UserId { get; set; }
		private string UserName { get; set; }

		public UserIdOrName(int id)
		{
			UserId = id;
		}

		public UserIdOrName(string userName)
		{
			UserName = userName;
		}

		public string GetKey()
		{
			if (UserId.HasValue)
			{
				return "user";
			}
			else if (!String.IsNullOrEmpty(UserName))
			{
				return "user:username";
			}
			throw new ArgumentException("Could not determine the user key");
		}

		public string GetValue()
		{
			if (UserId.HasValue)
			{
				return UserId.Value.ToString();
			}
			else if (!String.IsNullOrEmpty(UserName))
			{
				return UserName;
			}
			throw new ArgumentException("Could not determine the user value");
		}

		public static implicit operator UserIdOrName(string userName)
		{
			return new UserIdOrName(userName);
		}

		public static implicit operator UserIdOrName(int userId)
		{
			return new UserIdOrName(userId);
		}
	}

	public static class Resources
	{
		public static readonly string Users = "users";
	}
}