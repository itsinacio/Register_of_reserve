using TechNova.Api.Configurations;
using TechNova.Api.Repositories;
using TechNova.Api.Repositories.Impl;
using TechNova.Api.Services;
using TechNova.Api.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();

builder.Services.AddControllers();
builder.Services.AddDataBaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);
builder.Services.AddScoped<IReserveService, ReserveServiceImpl>();
builder.Services.AddScoped<IRoomService, RoomServiceImpl>();
builder.Services.AddScoped<IReserverRepository, ReserverRepositoryImpl>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();