using Microsoft.AspNetCore.Mvc;
using WebBiblioteca.Services.Interfaces;

namespace WebBiblioteca.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private ILoginService _loginService;

        public AuthController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        /// <summary>
        /// Login de Usuario 
        /// </summary>
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string username, string password)
        {
            var user = _loginService.Login(username, password);

            if (user != null)
            {
                return Ok(new { message = "Inicio de sesión exitoso" });
            }
            else 
            {
                return BadRequest("Usuario o Password incorrecto");
            }           
        }
    }
}
