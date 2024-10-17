using FluentValidation.AspNetCore;
using USP_API.Filters;
using USP_API.Services;
using USP_Application;
using USP_Infrastructure;
using USP_Worker;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>options.Filters.Add<ApiExceptionFilter>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IProductService, ProductService>();

builder.Services.AddHostedService<NotifyUserWorker>();
builder.Services.AddHostedService<UpdateProductEmbeddedWorker>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

public partial class Program { }