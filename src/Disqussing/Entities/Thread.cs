namespace Disqussing
{
	using System;
	using Newtonsoft.Json;

	public class Thread : Entity
	{
		private Forum forum;
		[JsonProperty("forum")]
		public Forum Forum
		{
			get { return forum; }
			set { forum = value; NotifyOfPropertyChange(() => Forum); }
		}

		private long author;
		[JsonProperty("author")]
		public long Author
		{
			get { return author; }
			set { author = value; NotifyOfPropertyChange(() => Author); }
		}
	}
}
