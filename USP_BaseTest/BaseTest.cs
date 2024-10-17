

using Microsoft.Extensions.DependencyInjection;
using MongoDB.Entities;
using Xunit;

namespace USP_BaseTest;

public class BaseTest:IAsyncLifetime
{
    public readonly HttpClient AnonymousClient;

    public BaseTest()
    {
        var factory = new CustomWebApplicationFactory<Program>();
        var scope = factory.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

        AnonymousClient = factory.CreateClient();
    }
    
    public Task InitializeAsync() => Task.CompletedTask;

    public async Task DisposeAsync()
    {
        await DB.Database("USPTestiranje").Client.DropDatabaseAsync("USPTestiranje");
    }
}