using AutoMapper;
using GlobalTickets.Application.Features.Categories.Queries.GetCategoriesList;
using GlobalTickets.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GlobalTickets.Application.Features.Events.Queries;
using GlobalTickets.Application.Features.Events.Queries.GetEventDetail;
using GlobalTickets.Application.Features.Events.Queries.GetEventsList;
using GlobalTickets.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
        }
    }
}
