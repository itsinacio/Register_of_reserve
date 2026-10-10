using TechNova.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();
builder.Services.AddDataBaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration,builder.Environment);
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.Run();