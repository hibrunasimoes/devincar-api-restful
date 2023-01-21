using System.Reflection;
using System.Text.Json.Serialization;
using DEVinCar.DI.IoC;
using DEVinCar.Domain.AutoMapper;
using DEVinCar.Domain.Security;
using DEVinCar.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(AutoMapperConfig.Configure());
builder.Services.AddDbContext<DevInCarDbContext>();
builder.Services.RegisterAuthentication();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// comentando para conseguir trabalhar com Insomnia/Postman via http comum
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
