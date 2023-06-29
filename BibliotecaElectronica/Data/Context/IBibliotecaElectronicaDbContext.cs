using BibliotecaElectronica.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaElectronica.Data.Context
{
    public interface IBibliotecaElectronicaDbContext
    {
        DbSet<Libro> Libros { get; set; }
        DbSet<Usuario> Usuarios { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}