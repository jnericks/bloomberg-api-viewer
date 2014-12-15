using System;
using bbapi.UI.Enums;

namespace bbapi.UI.ViewModels
{
    public class DefaultBloombergViewModel : BloombergViewModel
    {
        public DefaultBloombergViewModel()
        {
            var now = DateTime.Now;

            // Default Reference
            ReferenceSecurities = "ES1";
            ReferenceSecurityDatabase = SecurityDatabase.Index;
            ReferenceFields = "PX_LAST";
            StartDateReference = null;
            EndDateReference = null;

            // Default Historical
            HistoricalSecurities = "ES1";
            HistoricalSecurityDatabase = SecurityDatabase.Index;
            HistoricalFields = "PX_LAST";
            StartDateHistorical = new DateTime(now.Year, now.Month, 1);
            EndDateHistorical = new DateTime(now.Year, now.Month, 1).AddMonths(1).AddDays(-1);
            Periodicity = Periodicity.Monthly;
            CurrencyCodeHistorical = "USD";
            
            Log = string.Empty;
        }
    }
}