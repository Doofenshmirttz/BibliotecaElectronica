using BibliotecaElectronica.Data.Context;
using BibliotecaElectronica.Data.Models;
using BibliotecaElectronica.Data.Request;
using BibliotecaElectronica.Data.Response;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace BibliotecaElectronica.Data.Services
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

    }
    public class Result<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

    }
    public class LibroServices : ILibroServices
    {
        private readonly IBibliotecaElectronicaDbContext dbContext;

        public LibroServices(IBibliotecaElectronicaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(LibroRequest request)
        {
            try
            {
                var libro = Libro.Crear(request);
                dbContext.Libros.Add(libro);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(LibroRequest request)
        {
            try
            {
                var libro = await dbContext.Libros
                    .FirstOrDefaultAsync(l => l.Id == request.Id);
                if (libro == null)
                    return new Result() { Message = "No se encontro el libro", Success = false };

                if (libro.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(LibroRequest request)
        {
            try
            {
                var libro = await dbContext.Libros
                    .FirstOrDefaultAsync(l => l.Id == request.Id);
                if (libro == null)
                    return new Result() { Message = "No se encontro el Libro", Success = false };

                dbContext.Libros.Remove(libro);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<LibroResponse>>> Consultar(string filtro)
        {
            try
            {
                var libro = await dbContext.Libros
                    .Where(c =>
                        (c.Nombre + " " + c.Autor + " " + c.Genero)
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(l => l.ToResponse())
                    .ToListAsync();
                return new Result<List<LibroResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = libro
                };
            }
            catch (Exception E)
            {
                return new Result<List<LibroResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
