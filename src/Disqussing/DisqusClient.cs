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

    public class DisqusClient
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

		public User GetUser(string username)
		{
			var response = GetResponse(Version, "users", "details", new Dictionary<string, string>
				{
					{"user:username", username}
				});

			Response<User> r = SerializationHelper.DeserializeJson<Response<User>>(response.Body);

			return r.Data;
		}

		public HttpResponse GetResponse(string version, string resource, string method, Dictionary<string, string> queryStringArguments)
		{
			EnsureApiKey(queryStringArguments);
			Uri url = UrlHelper.BuildUrl(version, resource, method, queryStringArguments);
			return UrlClient.MakeRequest(url);
		}

		protected void EnsureApiKey(IDictionary<string, string> queryStringArguments)
		{
			if (!String.IsNullOrEmpty(ApiKey.Value) && !queryStringArguments.ContainsKey(ApiKey.ParameterName))
			{
				queryStringArguments.Add(ApiKey.ParameterName, ApiKey.Value);
			}
		}

    }
}