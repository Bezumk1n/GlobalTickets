using AutoMapper;
using GlobalTickets.Application.Features.Events.Commands.CreateEvent;
using GlobalTickets.Application.Interfaces.Persistence;
using GlobalTickets.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        public UpdateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }
        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.Id);
            _mapper.Map(source: request, destination: @event, typeof(UpdateEventCommand), typeof(Event));
            await _eventRepository.UpdateAsync(@event);
        }
    }
}
