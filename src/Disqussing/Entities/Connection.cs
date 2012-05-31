namespace Disqussing
{
	using Newtonsoft.Json;

	public class Connection : Entity
	{
		private string url;
		[JsonProperty("url")]
		public string Url
		{
			get { return url; }
			set { url = value; NotifyOfPropertyChange(() => Url); }
		}

		private string id;
		[JsonProperty("id")]
		public string Id
		{
			get { return id; }
			set { id = value; NotifyOfPropertyChange(() => Id); }
		}

		private string name;
		[JsonProperty("name")]
		public string Name
		{
			get { return name; }
			set { name = value; NotifyOfPropertyChange(() => Name); }
		}
	}
}
