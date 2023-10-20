using WebBiblioteca.Infraestructure;
using WebBiblioteca.Infraestructure.Entities;
using WebBiblioteca.Repository.Interfaces;

namespace WebBiblioteca.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly WebContext _context;

        public LibroRepository(WebContext context)
        {
            _context = context;
        }

        public List<Libro> GetAll()
        {
            var actualizado = _context.Libros.ToList();

            foreach(var libro in actualizado)
            {
                if (libro.Stock > 0)
                {
                    libro.Disponible = true;
                }
                else
                {
                    libro.Disponible = false;
                }
            }

            return actualizado;
        }

        public Libro GetLibroID(int ID)
        {
            return _context.Libros.Where(x => x.LibroID == ID).FirstOrDefault();
        }

        public Libro GetLibroISBN(string ISBN)
        {
            return _context.Libros.Where(x => x.ISBN == ISBN).FirstOrDefault();
        }

        public void CreateLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
        }

        public void UpdateStock(string ISBN, int stock)
        {
            var libro = _context.Libros.Where(_x => _x.ISBN == ISBN).FirstOrDefault();

            if (libro != null)
            {
                libro.Stock += stock;

                _context.Update(libro);
                _context.SaveChanges(true);
            }
        }

        public void DeleteLibro(Libro libro)
        {
            _context.Remove(libro);
            _context.SaveChanges(true);
        }
    }
}
