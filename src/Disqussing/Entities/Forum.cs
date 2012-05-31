namespace Disqussing
{
	using Newtonsoft.Json;

	public class Forum : Entity
	{
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

		private long founder;
		[JsonProperty("founder")]
		public long Founder
		{
			get { return founder; }
			set { founder = value; NotifyOfPropertyChange(() => Founder); }
		}

		private Favicon favicon;
		[JsonProperty("favicon")]
		public Favicon Favicon
		{
			get { return favicon; }
			set { favicon = value; NotifyOfPropertyChange(() => Favicon); }
		}
	}
}