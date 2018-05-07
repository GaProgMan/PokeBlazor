using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using PokeBlazor.Client.Services;

namespace PokeBlazor.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                services.AddSingleton<PokeState>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<Main>("app");
        }
    }
}
