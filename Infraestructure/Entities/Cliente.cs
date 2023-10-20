using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebBiblioteca.Infraestructure.Entities
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion {  get; set; }
        public string Telefono { get; set; }
        public int Dni {  get; set; }
        public Guid NumeroSocio { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Alquiler> Alquileres { get; set; }
        public ICollection<Libro> Libros { get; set; }
    }
}
