namespace BibliotecaElectronica.Data.Request
{
    public class LibroRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Autor { get; set; } = null!;

        public string Genero { get; set; } = null!;

        public byte[] Portada { get; set; } = null!;
    }
}
