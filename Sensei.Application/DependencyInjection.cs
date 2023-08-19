using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Sensei.Application;

public static class DependencyInjection
{
    public static void InjectApplicationDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}