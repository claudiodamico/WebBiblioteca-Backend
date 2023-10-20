using AutoMapper;
using WebBiblioteca.Domain;
using WebBiblioteca.Infraestructure.Entities;
using WebBiblioteca.Repository;
using WebBiblioteca.Repository.Interfaces;
using WebBiblioteca.Services.Interfaces;

namespace WebBiblioteca.Services
{
    public class LibroService : ILibroService
    {
        ILibroRepository _libroRepository;
        private readonly IMapper _mapper;
        public LibroService(ILibroRepository libroRepository,
            IMapper mapper)
        {
            _libroRepository = libroRepository;
            _mapper = mapper;
        }

        public List<Libro> GetAll()
        {
            return _libroRepository.GetAll();
        }

        public Libro GetLibroID(int ID)
        {
            return _libroRepository.GetLibroID(ID);
        }

        public Libro GetLibroISBN(string ISBN)
        {
            return _libroRepository.GetLibroISBN(ISBN);
        }

        public Libro CreateLibro(LibroDto libro)
        {
            var libroMapeado = _mapper.Map<Libro>(libro);
            _libroRepository.CreateLibro(libroMapeado);

            return libroMapeado;
        }

        public void UpdateStock(string ISBN, int stock)
        {
            _libroRepository.UpdateStock(ISBN, stock);
        }

        public void DeleteLibro(Libro libro)
        {
            _libroRepository.DeleteLibro(libro);
        }
    }
}
