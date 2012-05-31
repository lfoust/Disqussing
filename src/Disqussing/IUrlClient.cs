#if !SILVERLIGHT
using System;

namespace Disqussing
{
    public interface IUrlClient
    {
        HttpResponse MakeRequest(Uri url);
    }
}
#endif