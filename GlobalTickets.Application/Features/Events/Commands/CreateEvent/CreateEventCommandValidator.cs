﻿using FluentValidation;
using GlobalTickets.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace GlobalTickets.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0);

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists");
        }
        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)
        {
            var result = await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date);
            return result;
        }
    }
}
