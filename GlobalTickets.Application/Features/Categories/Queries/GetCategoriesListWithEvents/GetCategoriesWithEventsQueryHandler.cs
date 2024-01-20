using AutoMapper;
using GlobalTickets.Application.Features.Categories.Queries.GetCategoriesList;
using GlobalTickets.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    internal class GetCategoriesWithEventsQueryHandler : IRequestHandler<GetCategoriesWithEventsQuery, List<CategoryEventListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoriesWithEventsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryEventListVm>> Handle(GetCategoriesWithEventsQuery request, CancellationToken cancellationToken)
        {
            var allCategories = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
            return _mapper.Map<List<CategoryEventListVm>>(allCategories.ToList());
        }
    }
}
