using System;
using System.Collections.Generic;
using System.Linq;

namespace bbapi.Infrastructure
{
    public class ReferenceDataResponse
    {
        public IEnumerable<string> Messages { get; set; }

        public ReferenceDataResponse(IEnumerable<string> messages)
        {
            Messages = messages;
        }

        public override string ToString()
        {
            return Messages.Aggregate(string.Empty, (current, value) => current + Environment.NewLine + value);
        }
    }
}