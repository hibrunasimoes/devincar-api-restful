using System.Text.Json.Serialization;
using DEVinCar.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DevInCarDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// comentando para conseguir trabalhar com Insomnia/Postman via http comum
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
