using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using MongoDB.Entities;

namespace USP_BaseTest;

public class CustomWebApplicationFactory<TStartup>:WebApplicationFactory<TStartup> where TStartup : class
{
    public CustomWebApplicationFactory()
    {
        Task.Run(async () =>
        {
            await DB.InitAsync("USPTestiranje",
                MongoClientSettings.FromConnectionString(
                    "mongodb+srv://jovanilijevic21:hNW01dejzgp1MMoI@cluster-usp-1.wbefo.mongodb.net/"));
        })
        .GetAwaiter()
        .GetResult();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(IHostedService));

        });
    }
}