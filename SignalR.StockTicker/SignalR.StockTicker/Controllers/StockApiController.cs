using System;
using System.Net.Http;
using System.Web.Http;

namespace Microsoft.AspNet.SignalR.StockTicker.Controllers
{
    public class StockApiController : ApiController
    {
		private readonly Lazy<IHubContext> _dataHub = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<StockTickerHub>());

	    public IHttpActionResult GetCloseMarket()
	    {
		    _dataHub.Value.Clients.All.marketClosed();
		    return Ok();
	    }
    }
}
