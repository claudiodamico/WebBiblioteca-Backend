using AutoMapper;
using WebBiblioteca.Domain;
using WebBiblioteca.Infraestructure.Entities;
using WebBiblioteca.Repository;
using WebBiblioteca.Repository.Interfaces;
using WebBiblioteca.Services.Interfaces;

namespace WebBiblioteca.Services
{    
    public class ClienteService : IClienteService
    {
        IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository,
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public List<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente GetClienteByID(int ID)
        {
            return _clienteRepository.GetClienteByID(ID);
        }

        public Cliente GetClienteByDni(int Dni)
        {
            return _clienteRepository.GetClienteByDni(Dni);
        }

        public Cliente GetClienteByNroSocio(Guid nroSocio)
        {
            return _clienteRepository.GetClienteByNroSocio(nroSocio);
        }

        public Cliente CreateCliente(ClienteDto cliente)
        {
            var clienteMapeado = _mapper.Map<Cliente>(cliente);
            _clienteRepository.CreateCliente(clienteMapeado);

            return clienteMapeado;
        }

        public void DeleteCliente(Cliente cliente)
        {
            _clienteRepository.DeleteCliente(cliente);
        }
    }
}
