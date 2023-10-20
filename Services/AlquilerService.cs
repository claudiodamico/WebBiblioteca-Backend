using AutoMapper;
using WebBiblioteca.Domain;
using WebBiblioteca.Infraestructure.Entities;
using WebBiblioteca.Repository.Interfaces;
using WebBiblioteca.Services.Interfaces;

namespace WebBiblioteca.Services
{
    public class AlquilerService : IAlquilerService
    {
        IAlquilerRepository _alquilerRepository;
        private readonly IMapper _mapper;
        public AlquilerService(IAlquilerRepository alquilerRepository,
            IMapper mapper)
        {
            _alquilerRepository = alquilerRepository;
            _mapper = mapper;
        }

        public List<Alquiler> GetAll()
        {
            return _alquilerRepository.GetAll().ToList();
        }

        public Alquiler CreateAlquiler(AlquilerDto alquiler)
        {
            var alquilerMapeado = _mapper.Map<Alquiler>(alquiler);
            _alquilerRepository.CreateAlquiler(alquilerMapeado);

            return alquilerMapeado;
        }

        public void DeleteAlquiler(Alquiler alquiler)
        {
            _alquilerRepository.DeleteAlquiler(alquiler);
        }

        public Alquiler GetAlquilerByID(int ID)
        {
            return _alquilerRepository.GetAlquilerByID(ID);
        }
    }
}
