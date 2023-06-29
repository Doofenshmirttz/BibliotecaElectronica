using BibliotecaElectronica.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace BibliotecaElectronica.Data.Context
{
    public class BibliotecaElectronicaDbContext : DbContext, IBibliotecaElectronicaDbContext
    {
        private readonly IConfiguration config;
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public BibliotecaElectronicaDbContext(IConfiguration config)
        {
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("MSSQL"));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
