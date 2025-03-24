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


EventBus.Subscribe("OrderPlaced", (data) =>
{
    Console.WriteLine($"[InventoryService] (Simulated) Stock updated for product: {data}");
});
app.Run();