using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.ObjectPool;
using System.Text;

namespace RzComponents.Services.Extensions;

/// <summary>
/// 服务扩展类
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRzComponents(this IServiceCollection services)
    {
        //-------------------------------------------------------------------------------------
        services.TryAddScoped<ObjectPoolProvider, DefaultObjectPoolProvider>();

        //StringBuilder
        services.TryAddScoped<ObjectPool<StringBuilder>>(serviceProvider =>
        {
            var provider = serviceProvider.GetRequiredService<ObjectPoolProvider>();
            var policy = new StringBuilderPooledObjectPolicy();
            return provider.Create(policy);
        });


        //-------------------------------------------------------------------------------------

        return services;
    }
}

