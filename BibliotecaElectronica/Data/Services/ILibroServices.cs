using BibliotecaElectronica.Data.Request;
using BibliotecaElectronica.Data.Response;

namespace BibliotecaElectronica.Data.Services
{
    public interface ILibroServices
    {
        Task<Result<List<LibroResponse>>> Consultar(string filtro);
        Task<Result> Crear(LibroRequest request);
        Task<Result> Eliminar(LibroRequest request);
        Task<Result> Modificar(LibroRequest request);
    }
}