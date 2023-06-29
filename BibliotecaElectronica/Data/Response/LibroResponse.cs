
using BibliotecaElectronica.Data.Request;
namespace BibliotecaElectronica.Data.Response
{
    public class LibroResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Autor { get; set; } = null!;

        public string Genero { get; set; } = null!;

        public byte[] Portada { get; set; } = null!;

        public int IdUsuario { get; set; }

        public LibroRequest ToRequest() => new()
        {
            Id = Id,
            Nombre = Nombre,
            Autor = Autor,
            Genero = Genero,
            Portada = Portada,
            IdUsuario = IdUsuario

        };
    }
}
