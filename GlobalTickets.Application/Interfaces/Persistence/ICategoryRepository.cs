﻿using GlobalTickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Interfaces.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<IReadOnlyList<Category>> GetCategoriesWithEvents(bool includeHistory);
    }
}
