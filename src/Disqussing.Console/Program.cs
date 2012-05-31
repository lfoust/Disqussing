namespace Disqussing
{
	using System;
	using Ninject;
	using Ninject.Modules;

	class Program
	{
		static void Main(string[] args)
		{
			IKernel kernel = new StandardKernel(new DisqusModule());
			var program = kernel.Get<Shell>();
			program.Start();

			Console.WriteLine("Done.");
			Console.ReadLine();
		}
	}

	public class DisqusModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IUrlClient>().To<UrlClient>();
			Bind<IApiKey>().To<PrivateApiKey>().WithConstructorArgument("key", "");
			Bind<DisqusClient>().To<DisqusClient>().WithConstructorArgument("version", "3.0");
			Bind<IShell>().To<Shell>();
		}
	}

	public interface IShell
	{
		void Start();
	}

	public class Shell : IShell
	{
		private DisqusClient Client { get; set; }

		public Shell(DisqusClient client)
		{
			Client = client;
		}

		public void Start()
		{
			var user = Client.GetUser("lfoust");
			Console.WriteLine(user.Name);
		}
	}
}