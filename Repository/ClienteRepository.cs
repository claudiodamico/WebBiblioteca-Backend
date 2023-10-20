using WebBiblioteca.Infraestructure.Entities;
using WebBiblioteca.Infraestructure;
using WebBiblioteca.Repository.Interfaces;
using System.Linq;

namespace WebBiblioteca.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly WebContext _context;

        public ClienteRepository(WebContext context)
        {
            _context = context;
        }

        public List<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente GetClienteByID(int ID)
        {
            return _context.Clientes.Find(ID);
        }

        public Cliente GetClienteByDni(int Dni)
        {
            return _context.Clientes.SingleOrDefault(cliente => cliente.Dni == Dni);
        }

        public Cliente GetClienteByNroSocio(Guid nroSocio)
        {
            return _context.Clientes.FirstOrDefault(x => x.NumeroSocio == nroSocio);
        }


        public void CreateCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void DeleteCliente(Cliente cliente)
        {
            _context.Remove(cliente);
            _context.SaveChanges(true);
        }
    }
}
