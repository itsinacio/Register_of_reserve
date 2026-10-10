using Microsoft.EntityFrameworkCore;

namespace TechNova.Api.Model.Context;

public class SqlServerContext : DbContext
{
    public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }
    public DbSet<Room> Rooms {get; set;}
    public DbSet<Reserve> Reservations {get; set;}
}
