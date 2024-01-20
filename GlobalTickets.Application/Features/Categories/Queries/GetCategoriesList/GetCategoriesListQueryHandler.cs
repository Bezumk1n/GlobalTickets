using AutoMapper;
using GlobalTickets.Application.Features.Events.Queries.GetEventsList;
using GlobalTickets.Application.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesListQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        async Task<List<CategoryListVm>> IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>.Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryListVm>>(allCategories.ToList());
        }
    }
}
