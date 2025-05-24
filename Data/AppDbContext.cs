using AdquisicionesBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AdquisicionesBackend.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<RequerimientoAdquisicion> RequerimientosAdquisicion { get; set; }

    public DbSet<RequerimientoAdquisicionHistorico> RequerimientoAdquisicionHistoricos { get; set; }
  }
}
