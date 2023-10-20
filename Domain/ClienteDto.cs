using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Domain
{
    public class ClienteDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Dni { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
