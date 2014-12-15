namespace bbapi.Infrastructure
{
    public class BloombergSessionFactory : ICreateBloombergSession
    {
        public BloombergSession CreateSession()
        {
            return new BloombergSession();
        }
    }
}