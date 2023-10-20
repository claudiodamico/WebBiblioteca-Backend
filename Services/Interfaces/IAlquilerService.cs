using WebBiblioteca.Domain;
using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Services.Interfaces
{
    public interface IAlquilerService
    {
        Alquiler CreateAlquiler(AlquilerDto alquiler);
        List<Alquiler> GetAll();
        void DeleteAlquiler(Alquiler alquiler);
        Alquiler GetAlquilerByID(int ID);   
    }
}
