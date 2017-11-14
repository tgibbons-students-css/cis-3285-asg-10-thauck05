using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyTrader.Contracts;

namespace CurrencyTrader.AdoNet
{
    public class AsyncTradeStorage : ITradeStorage
    {
        private readonly ILogger logger;
        private ITradeStorage SyncTradeStorage;

        public AsyncTradeStorage(ILogger logger)
        {
            this.logger = logger;
            SyncTradeStorage = new AdoNetTradeStorage(logger);
        }

        public void Persist(IEnumerable<TradeRecord> trades)
        {
            logger.LogInfo("Starting synch trade storage");
            // SyncTradeStorage.Persist(trades);
            Task.Run(() => SyncTradeStorage.Persist(trades));
        }
    }
}
