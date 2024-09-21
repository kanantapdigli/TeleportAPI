using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleportAPI.Application.Clients.Teleport.Abstraction;
using TeleportAPI.Application.Clients.Teleport.Implementation;
using TeleportAPI.Application.Services.Abstraction;
using TeleportAPI.Application.Services.Implementation;

namespace TeleportAPI.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<ITeleportClient, TeleportClient>();
            services.AddScoped<ITeleportService, TeleportService>();
        }
    }
}
