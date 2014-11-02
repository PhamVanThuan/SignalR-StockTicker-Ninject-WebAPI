using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR.Infrastructure;
using Ninject;
using Owin;

namespace Microsoft.AspNet.SignalR.StockTicker
{
    public static class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
	        var kernel = new StandardKernel();

	        var resolver = new NinjectSignalRDependencyResolver(kernel);

			kernel.Bind<IStockTicker>()
				.To<StockTicker>()  // Bind to StockTicker.
				.InSingletonScope();  // Make it a singleton object.

			kernel.Bind(typeof(IHubConnectionContext<dynamic>)).ToMethod(context =>
					resolver.Resolve<IConnectionManager>().GetHubContext<StockTickerHub>().Clients
					 ).WhenInjectedInto<IStockTicker>();

			var config = new HubConfiguration {Resolver = resolver};
	        ConfigureSignalR(app, config);
        }

		public static void ConfigureSignalR(IAppBuilder app, HubConfiguration config)
		{
			app.MapSignalR(config);
		}
	}

}