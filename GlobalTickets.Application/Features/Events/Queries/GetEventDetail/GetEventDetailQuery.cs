using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Features.Events.Queries.GetEventDetail;

 public class GetEventDetailQuery : IRequest<EventDetailVm>
    {
        public Guid Id { get; private set;}
        private GetEventDetailQuery(){}
        public static GetEventDetailQuery Create(Guid eventId)
        {
            var result = new GetEventDetailQuery();
            result.Id = eventId;
            return result;
        }
    }
