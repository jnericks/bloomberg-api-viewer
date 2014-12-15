using System;
using System.Collections.Generic;

namespace bbapi.Infrastructure
{
    public class ReferenceDataRequest
    {
        public string[] Securities { get; protected set; }
        public string[] Fields { get; protected set; }
        public IDictionary<string, string> Overrides { get; protected set; }

        public ReferenceDataRequest(string[] securities, string[] fields)
        {
            Securities = securities;
            Fields = fields;
            Overrides = new Dictionary<string, string>();
        }

        public void AddOverride(string @override, string value)
        {
            if (Overrides.ContainsKey(@override))
                Overrides[@override] = value;
            else
                Overrides.Add(@override, value);
        }

        public void AddOverride(string @override, DateTime dateTime)
        {
            AddOverride(@override, dateTime.ToBBDateTimeString());
        }
    }
}