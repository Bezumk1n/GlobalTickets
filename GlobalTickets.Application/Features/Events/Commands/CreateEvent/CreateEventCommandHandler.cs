﻿using AutoMapper;
using GlobalTickets.Application.Exceptions;
using GlobalTickets.Application.Interfaces.Infrastructure;
using GlobalTickets.Application.Interfaces.Persistence;
using GlobalTickets.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly IEmailService _emailService;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _emailService = emailService;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var @event = _mapper.Map<Event>(request);
            @event = await _eventRepository.AddAsync(@event);
            try
            {
                var email = new Models.Mail.Email()
                {
                    To = "umnov.msk@gmail.com",
                    Body = $"A new event was created {request}",
                    Subject = "A new event was created" 
                };
                await _emailService.SendEmail(email);
            }
            catch (Exception)
            {

                throw;
            }
            return @event.Id;
        }
    }
}
