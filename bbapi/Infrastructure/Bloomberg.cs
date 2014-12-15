using System;
using System.Collections.Generic;
using System.Linq;

namespace bbapi.Infrastructure
{
    public class Bloomberg : ICanSubmitBloombergRequest
    {
        ICreateBloombergSession _sessionFactory;

        public Bloomberg()
        {
            _sessionFactory = new BloombergSessionFactory();
        }

        public ReferenceDataResponse SubmitRequest(ReferenceDataRequest request)
        {
            var messages = new List<string>
            {
                DateTime.Now.ToString(), 
                "-----"
            };

            using (var session = _sessionFactory.CreateSession())
            {
                var service = session.CreateService();

                var bbRequest = service.CreateBloombergRequest(request);

                var responseMessages = bbRequest.GetMessages();

                messages.Add(bbRequest.ToString());
                messages.AddRange(responseMessages.Select(x => x.ToString()));
            }

            return new ReferenceDataResponse(messages);
        }

        public HistoricalDataResponse SubmitRequest(HistoricalDataRequest request)
        {
            var messages = new List<string>
            {
                DateTime.Now.ToString(), 
                "-----"
            };

            using (var session = _sessionFactory.CreateSession())
            {
                var service = session.CreateService();

                var bbRequest = service.CreateBloombergRequest(request);

                var responseMessages = bbRequest.GetMessages();

                messages.Add(bbRequest.ToString());
                messages.AddRange(responseMessages.Select(x => x.ToString()));
            }

            return new HistoricalDataResponse(messages);
        }
    }
}