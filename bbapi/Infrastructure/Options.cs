using System;
using System.Linq;

namespace bbapi.Infrastructure
{
    public class Options
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Securities { get; set; }
        public string[] Fields { get; set; }
        public string PeriodicitySelection { get; set; }
        public string Currency { get; set; }

        public Options(DateTime startDate, DateTime endDate, string securities, string fields, string periodicitySelection, string currency)
        {
            StartDate = startDate.ToBBDateTimeString();
            EndDate = endDate.ToBBDateTimeString();
            Securities = securities;
            Fields = fields.Split(',').Select(x => x.Trim()).ToArray();
            PeriodicitySelection = periodicitySelection; // MONTHLY, DAILY
            Currency = currency; // USD
        }
    }
}