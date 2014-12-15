using System.Collections.Generic;
using System.Linq;
using Bloomberglp.Blpapi;

namespace bbapi.Infrastructure
{
    public class BloombergRequest
    {
        Request _request;
        Session _session;
        IList<BloombergMessage> _messages;
        bool _hasBeenSubmitted;

        public BloombergRequest(Request request, Session session)
        {
            _request = request;
            _session = session;
        }

        public IEnumerable<BloombergMessage> GetMessages()
        {
            if (!_hasBeenSubmitted)
            {
                _messages = GetMessagesFromRequestEvents().ToList();
                _hasBeenSubmitted = true;
            }

            return _messages;
        }

        IEnumerable<BloombergMessage> GetMessagesFromRequestEvents()
        {
            _session.SendRequest(_request, null);

            var continueToLoop = true;
            while (continueToLoop)
            {
                var @event = _session.NextEvent();
                switch (@event.Type)
                {
                    case Event.EventType.PARTIAL_RESPONSE:
                        foreach (var message in @event.GetMessages())
                            yield return new BloombergMessage(message);
                        break;
                    case Event.EventType.RESPONSE: // final event
                        foreach (var message in @event.GetMessages())
                            yield return new BloombergMessage(message);
                        continueToLoop = false;
                        break;
                }
            }
        }

        public override string ToString()
        {
            return _request.ToString();
        }
    }
}