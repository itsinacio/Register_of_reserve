using Microsoft.EntityFrameworkCore;
using TechNova.Api.Model.Context;

namespace TechNova.Api.Configurations;

public static class DataBaseConfig
{
    public static IServiceCollection AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var conectionString = configuration["MSSQLServerSQLConnection:MSSQLServerSQLConnectionString"];
        if(string.IsNullOrEmpty(conectionString)) throw new ArgumentNullException("Connection string 'MSSQLServerSQLConnectionString' not found"); 
        services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(conectionString));
        return services;
    }
}
