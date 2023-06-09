using RabbitMQ.MessagePublisher.Models;
using RabbitMQ.MessagePublisher.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions();
builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitConfigs"));

//RabbitMQ Custom Service
builder.Services.AddScoped<IMessageBrokerConnectionService, MessageBrokerConnectionService>();
builder.Services.AddScoped<IMessageBrokerService, MessageBrokerService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
