using WebBiblioteca.Infraestructure.Entities;
using WebBiblioteca.Infraestructure;
using WebBiblioteca.Services.Interfaces;
using WebBiblioteca.Repository.Interfaces;
using WebBiblioteca.Domain;

namespace WebBiblioteca.Repository
{
    public class AlquilerRepository : IAlquilerRepository
    {
        private readonly WebContext _context;

        public AlquilerRepository(WebContext context)
        {
            _context = context;
        }

        public List<Alquiler> GetAll()
        {
            var listaAlquileres = _context.Alquileres.ToList();
            return listaAlquileres;
        }

        public Alquiler GetAlquilerByID(int ID)
        {
            return _context.Alquileres.Find(ID);
        }

        public void CreateAlquiler(Alquiler alquiler)
        {
            var libroStock = _context.Libros.FirstOrDefault(x => x.ISBN == alquiler.ISBN);

            libroStock.Stock--; 

            _context.Libros.Update(libroStock);
            _context.SaveChanges();

            _context.Libros.Update(libroStock);
            _context.SaveChanges();

            _context.Alquileres.Add(alquiler);
            _context.SaveChanges();
        }

        public void DeleteAlquiler(Alquiler alquiler)
        {
            _context.Remove(alquiler);
            _context.SaveChanges(true);
        }        
    }
}
