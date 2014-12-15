using Bloomberglp.Blpapi;

namespace bbapi.Infrastructure
{
    public class BloombergMessage
    {
        Message _message;

        public BloombergMessage(Message message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return _message.ToString();
        }
    }
}