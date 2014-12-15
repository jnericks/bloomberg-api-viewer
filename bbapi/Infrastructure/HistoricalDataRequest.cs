using System;

namespace bbapi.Infrastructure
{
    public class HistoricalDataRequest
    {
        public string[] Securities { get; protected set; }
        public string[] Fields { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public string Periodicity { get; protected set; }
        public string CurrencyCode { get; protected set; }

        public HistoricalDataRequest(string[] securities, string[] fields, DateTime startDate, DateTime endDate, string periodicity, string currencyCode)
        {
            Securities = securities;
            Fields = fields;
            StartDate = startDate;
            EndDate = endDate;
            Periodicity = periodicity;
            CurrencyCode = currencyCode;
        }
    }
}