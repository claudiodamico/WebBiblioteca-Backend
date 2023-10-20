using WebBiblioteca.Infraestructure.Entities;
using WebBiblioteca.Repository.Interfaces;
using WebBiblioteca.Services.Interfaces;

namespace WebBiblioteca.Services
{
    public class LoginService : ILoginService
    {
        ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public Cliente Login(string username, string password)
        {
            return _loginRepository.Login(username, password);
        }
    }
}
