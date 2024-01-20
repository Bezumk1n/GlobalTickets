using GlobalTickets.Application.Features.Events.Queries.GetEventDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesWithEventsQuery : IRequest<List<CategoryEventListVm>>
    {
        public bool IncludeHistory { get; private set; }
        private GetCategoriesWithEventsQuery() { }
        public static GetCategoriesWithEventsQuery Create(bool _includeHistory)
        {
            var result = new GetCategoriesWithEventsQuery();
            result.IncludeHistory = _includeHistory;
            return result;
        }
    }
}
