using BibliotecaElectronica.Data.Request;
using BibliotecaElectronica.Data.Response;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace BibliotecaElectronica.Data.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Autor { get; set; } = null!;

        public string Genero { get; set; } = null!;

        public byte[] Portada { get; set; } = null!;

        public int IdUsuario { get; set; }


        public static Libro Crear(LibroRequest libro) => new()
        {
            Id = libro.Id,
            Nombre = libro.Nombre,
            Autor = libro.Autor,
            Genero = libro.Genero,
            Portada = libro.Portada,
            IdUsuario = libro.IdUsuario

        };


        public bool Modificar(LibroRequest libro)
        {
            var cambio = false;
            if (Nombre != libro.Nombre)
            {
                Nombre = libro.Nombre;
                cambio = true;
            }

            if (Autor != libro.Autor)
            {
                Autor = libro.Autor;
                cambio = true;
            }

            if (Genero != libro.Genero)
            {
                Genero = libro.Genero;
                cambio = true;
            }

            if (!Portada.SequenceEqual(libro.Portada))
            {
                Portada = libro.Portada;
                cambio = true;
            }



            return cambio;

        }

        public LibroResponse ToResponse()
       => new()
       {
           Id = Id,
           Nombre = Nombre,
           Autor = Autor,
           Portada = Portada,
           Genero = Genero,
           IdUsuario = IdUsuario
       };
    }

    
}
