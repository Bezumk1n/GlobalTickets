﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Features.Categories.Queries.GetCategoriesList
{
    internal class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
    {
    }
}
