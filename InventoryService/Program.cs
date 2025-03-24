using InventoryService.Services;
using Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
new RabbitMQSubscriber();
// 👂 SUBSCRIBE TO EVENT
EventBus.Subscribe("OrderPlaced", (data) =>
{
    Console.WriteLine($"[InventoryService] Stock updated for product: {data}");
});

app.Run();
