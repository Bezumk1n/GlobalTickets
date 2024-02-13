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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(GlobalTicketsDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IReadOnlyList<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            var orders = await _dbContext.Orders
                .Where(q => q.OrderPlaced.Month == date.Month && q.OrderPlaced.Year == date.Year)
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToListAsync();
            return orders;
        }
        public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
        {
            var count = await _dbContext.Orders.CountAsync(q => q.OrderPlaced.Month == date.Month && q.OrderPlaced.Year == date.Year);
            return count;
        }
    }
}
