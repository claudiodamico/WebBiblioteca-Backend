using WebBiblioteca.Infraestructure.Entities;

namespace WebBiblioteca.Services.Interfaces
{
    public interface ILoginService
    {
        Cliente Login(string username, string password);
    }
}
