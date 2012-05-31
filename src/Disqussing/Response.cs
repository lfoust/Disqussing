namespace Disqussing
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Response<T> : Entity
    {
		private int code;
		[JsonProperty("code")]
		public int Code
		{
			get { return code; }
			set { code = value; NotifyOfPropertyChange(() => Code); }
		}

		private T data;
		[JsonProperty("response")]
		public T Data
		{
			get { return data; }
			set { data = value; NotifyOfPropertyChange(() => Data); }
		}
    }
}