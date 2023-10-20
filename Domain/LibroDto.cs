using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Domain
{
    public class LibroDto
    {
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string ISBN { get; set; }
        public int Paginas { get; set; }
        public string Clasificacion { get; set; }
        public string Idioma { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
    }
}
