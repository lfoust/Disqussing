namespace Disqussing.Entities
{
	using Newtonsoft.Json;

	public class Avatar : ImageReference
	{
		private bool isCustom;
		[JsonProperty("isCustom")]
		public bool IsCustom
		{
			get { return isCustom; }
			set { isCustom = value; NotifyOfPropertyChange(() => IsCustom); }
		}

		private ImageReference small;
		[JsonProperty("small")]
		public ImageReference Small
		{
			get { return small; }
			set { small = value; NotifyOfPropertyChange(() => Small); }
		}

		private ImageReference large;
		[JsonProperty("large")]
		public ImageReference Large
		{
			get { return large; }
			set { large = value; NotifyOfPropertyChange(() => Large); }
		}
	}
}
