using WebBiblioteca.Domain;
using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Services.Interfaces
{
    public interface ILibroService
    {
        List<Libro> GetAll();
        Libro GetLibroID(int ID);
        Libro GetLibroISBN(string ISBN);
        Libro CreateLibro(LibroDto libro);
        void UpdateStock(string ISBN, int stockToAdd);
        void DeleteLibro(Libro libro);
    }
}
