using WebBiblioteca.Domain;
using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Services.Interfaces
{
    public interface IClienteService
    {
        List<Cliente> GetAll();
        Cliente GetClienteByID(int ID);
        Cliente GetClienteByDni(int Dni);
        Cliente GetClienteByNroSocio(Guid nroSocio);
        Cliente CreateCliente(ClienteDto cliente);
        void DeleteCliente(Cliente cliente);
    }
}
