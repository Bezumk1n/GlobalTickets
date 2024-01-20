using GlobalTickets.Application.Features.Events.Commands.CreateEvent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public Guid Id { get; private set; }
        private DeleteEventCommand() { }
        public static DeleteEventCommand Create(Guid id)
        {
            var result = new DeleteEventCommand();
            result.Id = id;
            return result;
        }
    }
}
