using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace WebBiblioteca.Infraestructure.Entities
{
    public class Libro
    {
        [Key]
        public int LibroID { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string ISBN { get; set; }
        public int Paginas { get; set; }
        public string Clasificacion { get; set; }
        public string Idioma { get; set; }
        public int Stock {  get; set; }
        public bool Disponible { get; set; } = true;
        public string Imagen {  get; set; }

        // Propiedades de navegación
        public ICollection<Alquiler> Alquileres { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
