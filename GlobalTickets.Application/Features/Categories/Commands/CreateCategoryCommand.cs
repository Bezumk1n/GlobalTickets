using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; private set; } = string.Empty;
        private CreateCategoryCommand() { }
        public static CreateCategoryCommand Create(string name)
        { 
            var result = new CreateCategoryCommand();
            result.Name = name;
            return result;
        }
    }
}
