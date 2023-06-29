using BibliotecaElectronica.Data.Request;
using BibliotecaElectronica.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaElectronica.Data.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = null!;
        public string Clave { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public virtual List<Libro> Libros { get; set; }

        public static Usuario Crear(UsuarioRequest usuario) => new()
        {
            IdUsuario = usuario.IdUsuario,
            NombreUsuario = usuario.NombreUsuario,
            Clave = usuario.Clave,
            Libros = usuario.Libros,
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido
          

        };


        public bool Modificar(UsuarioRequest usuario)
        {
            var cambio = false;

            if (IdUsuario != usuario.IdUsuario)
            {
                IdUsuario = usuario.IdUsuario;
                cambio = true;
            }

            if (NombreUsuario != usuario.NombreUsuario)
            {
                NombreUsuario = usuario.NombreUsuario;
                cambio = true;
            }

            if (Clave != usuario.Clave)
            {
                Clave = usuario.Clave;
                cambio = true;
            }

            if (!Libros.Equals(usuario.Libros))
            {
                Libros = usuario.Libros;
                cambio = true;
            }

            if (Nombre != usuario.Nombre)
            {
                Nombre = usuario.Nombre;
                cambio = true;
            }

            if (Apellido != usuario.Apellido)
            {
                Apellido = usuario.Apellido;
                cambio = true;
            }

            return cambio;
        }

        public UsuarioResponse ToResponse() => new UsuarioResponse()
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
