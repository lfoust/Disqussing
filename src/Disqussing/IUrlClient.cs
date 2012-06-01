#if !SILVERLIGHT
using System;

namespace Disqussing
{
    public interface IUrlClient
    {
        HttpResponse MakeRequest(Uri url, HttpMethod method = HttpMethod.GET);
    }

	public enum HttpMethod
	{
		GET,
		POST
	}
}
#endif