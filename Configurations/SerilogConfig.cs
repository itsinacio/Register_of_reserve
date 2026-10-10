using Serilog;

namespace TechNova.Api.Configurations;

public static class SerilogConfig
{
    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.Debug()
            .CreateLogger();
        builder.Host.UseSerilog();
    }
}
