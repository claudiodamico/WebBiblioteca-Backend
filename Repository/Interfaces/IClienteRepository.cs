using WebBiblioteca.Domain;
using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Repository.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> GetAll();
        void CreateCliente(Cliente cliente);
        Cliente GetClienteByID(int iD);
        void DeleteCliente(Cliente cliente);
        Cliente GetClienteByDni(int dni);
        Cliente GetClienteByNroSocio(Guid nroSocio);
    }
}
