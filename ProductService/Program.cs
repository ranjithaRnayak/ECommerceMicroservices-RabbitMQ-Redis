var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

// Disable HTTPS redirection for local (no HTTPS port set)
app.UseAuthorization();

app.MapControllers(); // 👈 VERY important for routing

app.Run();
