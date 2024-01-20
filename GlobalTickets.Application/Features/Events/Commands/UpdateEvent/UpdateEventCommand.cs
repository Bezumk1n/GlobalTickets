using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; private set; } = string.Empty;
        public int Price { get; private set; }
        public string? Artist { get; private set; }
        public DateTime Date { get; private set; }
        public string? Description { get; private set; }
        public string? ImageUrl { get; private set; }
        public Guid CategoryId { get; private set; }
        private UpdateEventCommand() { }
        public static UpdateEventCommand Create(Guid id, string name, int price, string artist, DateTime date, string description, string imageUrl, Guid categoryId)
        {
            var result = new UpdateEventCommand();
            result.Id = id;
            result.Name = name;
            result.Price = price;
            result.Artist = artist;
            result.Date = date;
            result.Description = description;
            result.ImageUrl = imageUrl;
            result.CategoryId = categoryId;
            return result;
        }
    }
}
