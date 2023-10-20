using NSwag.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WebBiblioteca.Infraestructure.Entities
{
    public class Alquiler
    {
        [Key]
        [SwaggerIgnore]
        public int AlquilerID { get; set; }
        public string NumeroSocio { get; set; }
        public string ISBN { get; set; }
        public DateTime FechaAlquiler { get; set; } = DateTime.Now;
        public DateTime FechaDevolucion { get; set; } = DateTime.Now.AddDays(7);
        public string Observaciones { get; set; }
        [SwaggerIgnore]
        public ICollection<Libro> Libros { get; set; }
        [SwaggerIgnore]
        public ICollection<Cliente> Clientes { get; set; }
    }
}
