using GlobalTickets.Application.Interfaces.Persistence;
using GlobalTickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(GlobalTicketsDbContext dbContext) : base(dbContext)
        {
        }
        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            var matches = _dbContext.Events.Any(e => e.Name == name && e.Date == eventDate);

            return Task.FromResult(matches);
        }
    }
}
