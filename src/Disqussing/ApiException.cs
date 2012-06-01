using System;

namespace Disqussing
{
    public class ApiException : Exception
    {
        public Uri Url {get;set;}

        public ApiException() { }

        public ApiException(Exception innerException, Uri url)
            : base("Error with url: " + url.ToString(), innerException)
        {
            Url = url;
        }

        public ApiException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }

		public ApiException(string message)
			: base(message)
		{
		}
    }
}