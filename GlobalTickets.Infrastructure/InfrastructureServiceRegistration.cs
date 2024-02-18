using GlobalTickets.Application.Interfaces.Infrastructure;
using GlobalTickets.Application.Models.Mail;
using GlobalTickets.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTickets.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            service.AddTransient<IEmailService, EmailService>();
            return service;
        }
    }
}
