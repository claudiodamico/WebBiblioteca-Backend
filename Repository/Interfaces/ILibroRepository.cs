using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Repository.Interfaces
{
    public interface ILibroRepository
    {
        List<Libro> GetAll();
        Libro GetLibroID(int ID);
        void CreateLibro(Libro libro);
        void DeleteLibro(Libro libro);
        Libro GetLibroISBN(string ISBN);
        void UpdateStock(string iSBN, int stock);
    }
}
