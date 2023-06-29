using BibliotecaElectronica.Data.Request;
using BibliotecaElectronica.Data.Response;

namespace BibliotecaElectronica.Data.Services
{
    public interface IUsuarioServices
    {
        Task<Result<UsuarioResponse>> Consultar(UsuarioRequest usuario);
        Task<Result<UsuarioResponse>> ConsultarUsuario(int Id);
        Task<Result> Crear(UsuarioRequest request);
        Task<Result> Eliminar(UsuarioRequest request);
        Task<Result> Modificar(UsuarioRequest request);
    }
}