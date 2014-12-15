namespace bbapi.Infrastructure
{
    public interface ICanSubmitBloombergRequest
    {
        ReferenceDataResponse SubmitRequest(ReferenceDataRequest request);
        HistoricalDataResponse SubmitRequest(HistoricalDataRequest request);
    }
}