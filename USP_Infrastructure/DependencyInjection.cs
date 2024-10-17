
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Entities;
using USP_Application.Common.Interfaces;
using USP_Infrastructure.Services;

namespace USP_Infrastructure;

public static class DependencyInjection
{ 
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {     
        //var mongoDbConfiguration = new MongoDbConfiguration();
              var conn = configuration.GetSection("MongoDbConfiguration");
              
              Task.Run(async () =>    
                {
                     await DB.InitAsync(conn.GetSection("DbName").Value!,
                     MongoClientSettings.FromConnectionString(conn.GetSection("DbString").Value));
                 })         
                  .GetAwaiter()        
                  .GetResult();     
              services.AddSingleton<IProductService,ProductService>();
              return services;
              
    }}


