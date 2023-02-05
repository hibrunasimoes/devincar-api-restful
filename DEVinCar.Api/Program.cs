using System.Reflection;
using System.Text.Json.Serialization;
using DEVinCar.Api.Configuration;
using DEVinCar.DI.IoC;
using DEVinCar.Domain.AutoMapper;
using DEVinCar.Domain.Security;
using DEVinCar.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(AutoMapperConfig.Configure());
builder.Services.AddDbContext<DevInCarDbContext>();


builder.Services.RegisterAuthentication();

builder.Services.AddMvc(config => {
    config.ReturnHttpNotAcceptable = true;
    config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
    config.InputFormatters.Add(new XmlSerializerInputFormatter(config));
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header usando o esquema Bearer.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
                {
                Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                    },
                },
            new List<string>()
        }
    });
});

var app = builder.Build();
app.UseMiddleware<ErrorMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// comentando para conseguir trabalhar com Insomnia/Postman via http comum

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
