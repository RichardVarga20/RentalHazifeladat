using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Szolg�ltat�sok regisztr�l�sa a kont�nerekhez.
builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddDbContext<VehicleRentalContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger csak fejleszt�si k�rnyezetben
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
