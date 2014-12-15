using System;
using System.Collections.Generic;
using System.Linq;

namespace bbapi.Infrastructure
{
    public class HistoricalDataResponse
    {
        public IEnumerable<string> Messages { get; protected set; }

        public HistoricalDataResponse(IEnumerable<string> messages)
        {
            Messages = messages;
        }

        public override string ToString()
        {
            return Messages.Aggregate(string.Empty, (current, value) => current + Environment.NewLine + value);
        }
    }
}