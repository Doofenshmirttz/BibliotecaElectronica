using System.ComponentModel.DataAnnotations;
using BibliotecaElectronica.Data.Models;

namespace BibliotecaElectronica.Data.Request
{
    public class UsuarioRequest
    {

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "NombreUsuario")]
        public string NombreUsuario { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Clave")]
        public string Clave { get; set; } = null!;


        
        public string Nombre { get; set; } = null!;


        
        public string Apellido { get; set; } = null!;
        public virtual List<Libro> Libros { get; set; }

    }
}
