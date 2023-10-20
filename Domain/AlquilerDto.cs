using System.ComponentModel.DataAnnotations;
using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Domain
{
    public class AlquilerDto
    {
        public string NumeroSocio { get; set; }
        public string ISBN { get; set; }
        public string Observaciones { get; set; }
    }
}
