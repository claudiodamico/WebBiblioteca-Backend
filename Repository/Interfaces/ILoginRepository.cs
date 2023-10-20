using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Repository.Interfaces
{
    public interface ILoginRepository
    {
        Cliente Login(string username, string password);
    }
}
