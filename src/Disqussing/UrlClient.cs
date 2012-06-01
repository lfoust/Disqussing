using System;
using System.IO;
using System.Net;

namespace Disqussing
{
    public class UrlClient : IUrlClient
    {
        public HttpResponse MakeRequest(Uri url, HttpMethod method = HttpMethod.GET)
        {
            HttpResponse httpResponse = new HttpResponse
            {
                Url = url
            };
            var request = WebRequest.Create(url) as HttpWebRequest;
            if (request != null)
            {
                request.UserAgent = "Disqussing";
				request.Method = method.ToString();
                try
                {
                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        using (var responseStream = response.GetResponseStream())
                        {
                            var reader = new StreamReader(responseStream);
                            httpResponse.Body = reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException e)
                {
                    httpResponse.Error = e;
                    if (e.Status == WebExceptionStatus.ProtocolError && e.Response != null)
                    {
                        var response = (HttpWebResponse)e.Response;
                        if (response.StatusCode != HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.ProxyAuthenticationRequired)
                        {
                            using (var responseStream = response.GetResponseStream())
                            {
                                using (var reader = new StreamReader(responseStream))
                                {
                                    httpResponse.Body = reader.ReadToEnd();
                                }
                            }
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
            return httpResponse;
        }
    }
}