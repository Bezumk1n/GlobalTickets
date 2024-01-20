using GlobalTickets.Application.Features.Events.Queries.GetEventDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public string Name { get; private set; } = string.Empty;
        public int Price { get; private set; }
        public string? Artist { get; private set; }
        public DateTime Date { get; private set; }
        public string? Description { get; private set; }
        public string? ImageUrl { get; private set; }
        public Guid CategoryId { get; private set; }
        private CreateEventCommand() { }
        public static CreateEventCommand Create(string name, int price, string artist, DateTime date, string description, string imageUrl, Guid categoryId)
        {
            var result = new CreateEventCommand();
            result.Name = name;
            result.Price = price;
            result.Artist = artist;
            result.Date = date;
            result.Description = description;
            result.ImageUrl = imageUrl;
            result.CategoryId = categoryId;
            return result;
        }
        public override string ToString()
        {
            return $"Event name: {Name}; Price: {Price}; By {Artist}; On: {Date.ToShortDateString()}; Description {Description}";
        }
    }
}
