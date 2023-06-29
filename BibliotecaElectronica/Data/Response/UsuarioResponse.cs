using BibliotecaElectronica.Data.Models;
using BibliotecaElectronica.Data.Request;

namespace BibliotecaElectronica.Data.Response
{
    public class UsuarioResponse
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Clave { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;
        public virtual List<Libro> Libros { get; set; }


        public UsuarioRequest toRequest() => new UsuarioRequest()
        {
            IdUsuario = IdUsuario,
            NombreUsuario = NombreUsuario,
            Clave = Clave,
            Libros = Libros,
            Nombre = Nombre,
            Apellido = Apellido
        };
    }        
}
