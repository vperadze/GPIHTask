using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GPIHTask.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
