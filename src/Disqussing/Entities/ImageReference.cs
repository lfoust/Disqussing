namespace Disqussing
{
	using Newtonsoft.Json;

	public class ImageReference : Entity
	{
		private string permalink;
		[JsonProperty("permalink")]
		public string Permalink
		{
			get { return permalink; }
			set { permalink = value; NotifyOfPropertyChange(() => Permalink); }
		}

		private string cache;
		[JsonProperty("cache")]
		public string Cache
		{
			get { return cache; }
			set { cache = value; NotifyOfPropertyChange(() => Cache); }
		}
	}
}