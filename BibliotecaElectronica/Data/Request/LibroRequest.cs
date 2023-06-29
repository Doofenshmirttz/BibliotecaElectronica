using System.ComponentModel.DataAnnotations;

namespace BibliotecaElectronica.Data.Request
{
    public class LibroRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;


        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Autor")]
        public string Autor { get; set; } = null!;


        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Genero")]
        public string Genero { get; set; } = null!;

        [Required(ErrorMessage = "Debe de introducir una portada")]
        [Display(Name = "Portada")]
        public byte[] Portada { get; set; } = null!;

        public int IdUsuario { get; set; }
    }
}
