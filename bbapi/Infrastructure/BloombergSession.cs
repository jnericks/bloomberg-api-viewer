using System;
using System.Collections.Generic;
using Bloomberglp.Blpapi;

namespace bbapi.Infrastructure
{
    public class BloombergSession : IDisposable
    {
        Session _session;

        public BloombergSession()
        {
            _session = new Session(new SessionOptions { ServerHost = "localhost", ServerPort = 8194 });
        }

        public BloombergService CreateService()
        {
            const string serviceName = "//blp/refdata";
            
            if (_session.Start() && _session.OpenService(serviceName))
                return new BloombergService(_session.GetService(serviceName), _session);
            
            throw new Exception("Cannot connect to Bloomberg server. Check to make sure that bbcomm.exe process is running.");
        }

        public IEnumerable<Event> SendRequest(Request request)
        {
            _session.SendRequest(request, null);

            var continueToLoop = true;
            while (continueToLoop)
            {
                var @event = _session.NextEvent();
                switch (@event.Type)
                {
                    case Event.EventType.PARTIAL_RESPONSE:
                        yield return @event;
                        break;
                    case Event.EventType.RESPONSE: // final event
                        yield return @event;
                        continueToLoop = false;
                        break;
                }
            }
        }

        public void Dispose()
        {
            _session.Stop();
            _session.Dispose();
        }
    }
}