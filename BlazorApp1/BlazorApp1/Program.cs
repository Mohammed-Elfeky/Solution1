using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using models;
using BlazorApp1.myServices;
namespace BlazorApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped(sp =>
                 new HttpClient
                 {
                     BaseAddress = new Uri(sp.GetRequiredService<IConfiguration>()["base"])
                 });
            builder.Services.AddScoped<IService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            await builder.Build().RunAsync();
        }
    }
}
