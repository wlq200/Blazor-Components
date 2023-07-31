using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RzComponents.Services.Extensions;

namespace PM.Client.Infrastructure.Extensions;

internal static class WebAssemblyHostBuilderExtensions
{
    public static WebAssemblyHostBuilder AddClientServices(this WebAssemblyHostBuilder builder)
    {
        //--------------------------------------------------
        //HttpClient Service
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        //--------------------------------------------------
        //RzComponent Services
        builder.Services.AddRzComponents();


        //--------------------------------------------------
        return builder;
    }
}
