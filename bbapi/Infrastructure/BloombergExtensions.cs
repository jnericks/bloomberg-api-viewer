using System;
using Bloomberglp.Blpapi;

namespace bbapi.Infrastructure
{
    public static class BloombergExtensions
    {
        public static void AddOverride(this Request request, string fieldId, string fieldValue)
        {
            var overrides = request.GetElement(@"overrides");
            var @override = overrides.AppendElement();
            @override.SetElement(@"fieldId", fieldId);
            @override.SetElement(@"value", fieldValue);
        }

        public static string ToBBDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString(@"yyyyMMdd");
        }
    }
}
