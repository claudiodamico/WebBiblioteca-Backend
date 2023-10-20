using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Repository.Interfaces
{
    public interface IAlquilerRepository
    {
        void CreateAlquiler(Alquiler alquiler);
        List<Alquiler> GetAll();
        void DeleteAlquiler(Alquiler alquiler);
        Alquiler GetAlquilerByID(int ID);
    }
}
