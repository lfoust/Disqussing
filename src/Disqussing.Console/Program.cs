using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disqussing
{
	class Program
	{
		static void Main(string[] args)
		{
			DisqusClient client = new DisqusClient(new PrivateApiKey(""), "3.0", new UrlClient());
			var user = client.GetUser("lfoust");
			Console.WriteLine(user.Name);
			Console.WriteLine("Done.");
			Console.ReadLine();
		}
	}
}
