using Walaks.Poc.Minimal.Api.Application.Services;
using Walaks.Poc.Minimal.Api.Application.Services.Interfaces;
using Walaks.Poc.Minimal.Api.Endpoints;
using Walaks.Poc.Minimal.Api.Infrastructure.Context;
using Walaks.Poc.Minimal.Api.Infrastructure.Repository;
using Walaks.Poc.Minimal.Api.Infrastructure.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<EntityContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRoutes();

app.ExtensionRoutes();

app.Run();
