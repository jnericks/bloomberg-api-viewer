using Bloomberglp.Blpapi;

namespace bbapi.Infrastructure
{
    public class BloombergService
    {
        Service _service;
        Session _session;

        public BloombergService(Service service, Session session)
        {
            _service = service;
            _session = session;
        }

        public BloombergRequest CreateBloombergRequest(ReferenceDataRequest request)
        {
            var result = _service.CreateRequest("ReferenceDataRequest");

            foreach (var security in request.Securities)
                result.Append("securities", security);

            foreach (var field in request.Fields)
                result.Append("fields", field);

            foreach (var @override in request.Overrides)
                result.AddOverride(@override.Key, @override.Value);

            return new BloombergRequest(result, _session);
        }

        public BloombergRequest CreateBloombergRequest(HistoricalDataRequest request)
        {
            var result = _service.CreateRequest("HistoricalDataRequest");

            foreach (var security in request.Securities)
                result.Append("securities", security);

            foreach (var field in request.Fields)
                result.Append("fields", field);

            result.Set("startDate", request.StartDate.ToBBDateTimeString());
            result.Set("endDate", request.EndDate.ToBBDateTimeString());
            result.Set("periodicitySelection", request.Periodicity);
            result.Set("currency", request.CurrencyCode);

            return new BloombergRequest(result, _session);
        }
    }
}