using AutoMapper;
using GlobalTickets.Application.Features.Categories.Commands;
using GlobalTickets.Application.Features.Categories.Queries.GetCategoriesList;
using GlobalTickets.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GlobalTickets.Application.Features.Events.Commands.CreateEvent;
using GlobalTickets.Application.Features.Events.Commands.DeleteEvent;
using GlobalTickets.Application.Features.Events.Commands.UpdateEvent;
using GlobalTickets.Application.Features.Events.Queries;
using GlobalTickets.Application.Features.Events.Queries.GetEventDetail;
using GlobalTickets.Application.Features.Events.Queries.GetEventsList;
using GlobalTickets.Application.Features.Orders.Queries.GetOrdersForMonth;
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
            CreateMap<Event, CategoryEventDto>();
            CreateMap<CreateEventCommand, Event>();
            CreateMap<UpdateEventCommand, Event>();
            CreateMap<DeleteEventCommand, Event>();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
