namespace Disqussing
{
	using Newtonsoft.Json;

	public class Connections : Entity
	{
		private Connection twitter;
		[JsonProperty("twitter")]
		public Connection Twitter
		{
			get { return twitter; }
			set { twitter = value; NotifyOfPropertyChange(() => Twitter); }
		}

		private Connection facebook;
		[JsonProperty("facebook")]
		public Connection Facebook
		{
			get { return facebook; }
			set { facebook = value; NotifyOfPropertyChange(() => Facebook); }
		}
	}
}
