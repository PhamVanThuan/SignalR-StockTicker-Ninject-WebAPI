using System.Collections.Generic;

namespace Microsoft.AspNet.SignalR.StockTicker
{
	public interface IStockTicker
	{
		MarketState MarketState { get; }
		IEnumerable<Stock> GetAllStocks();
		void OpenMarket();
		void CloseMarket();
		void Reset();
	}
}