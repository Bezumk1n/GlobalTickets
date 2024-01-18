using AutoMapper;
using GlobalTickets.Application.Interfaces.Persistence;
using GlobalTickets.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventVm>>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        public GetEventsListQueryHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }
        public async Task<List<EventVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = await _eventRepository.GetAllAsync();
            var orderedEvents = allEvents.OrderBy(q => q.Date);
            return _mapper.Map<List<EventVm>>(orderedEvents);
        }
    }
}
