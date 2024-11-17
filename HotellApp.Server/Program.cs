using HotellApp.Data;
using HotellApp.Server.Commands;
using HotellApp.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", builder =>
	builder.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader());
});

builder.Services.AddDbContext<HotellAppDbContext>(options =>
{
	options.UseSqlServer("Server=localhost;Database=HotellAppDb;Trusted_Connection=True;TrustServerCertificate=True");
});

// Add Services
builder.Services.AddScoped<IHotellManagementService, HotellManagementService>();
builder.Services.AddScoped<IBookingService, BookingService>();

// Add Commands
builder.Services.AddScoped<AddRoomToDatabase>();
builder.Services.AddScoped<GetAllRoomsFromDatabase>();
builder.Services.AddScoped<DeleteRoomFromDatabase>();
builder.Services.AddScoped<GetAllVacantRoomsFromDatabase>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
