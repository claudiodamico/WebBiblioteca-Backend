using WebBiblioteca.Infraestructure;
using WebBiblioteca.Infraestructure.Entities;
using WebBiblioteca.Repository.Interfaces;

namespace WebBiblioteca.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly WebContext _context;

        public LoginRepository(WebContext webContext)
        {
            _context = webContext;
        }
        public Cliente Login(string username, string password)
        {
            return _context.Clientes.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
