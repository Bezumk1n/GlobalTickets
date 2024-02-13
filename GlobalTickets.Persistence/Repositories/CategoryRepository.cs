using GlobalTickets.Application.Interfaces.Persistence;
using GlobalTickets.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GlobalTicketsDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<Category>> GetCategoriesWithEvents(bool includeHistory)
        {
            var allCategories = await _dbContext.Categories
                .Include(q => q.Events)
                .ToListAsync();
            if (!includeHistory)
            {
                allCategories.ForEach(q => q.Events.ToList().RemoveAll(r => r.Date < DateTime.Today));
            }
            return allCategories;
        }
    }
}
