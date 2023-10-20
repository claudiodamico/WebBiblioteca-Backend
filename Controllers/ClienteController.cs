using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebBiblioteca.Domain;
using WebBiblioteca.Infraestructure.Entities;
using WebBiblioteca.Services;
using WebBiblioteca.Services.Interfaces;

namespace WebBiblioteca.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteservice;
        private readonly IMapper _mapper;
        public ClienteController(IClienteService clienteService,
            IMapper mapper)
        {
            _clienteservice = clienteService;
            _mapper = mapper;
        }

        /// <summary>
        /// Filtrar todos los Clientes 
        /// </summary>
        [HttpGet("all")]
        public List<Cliente> GetAll()
        {
            var cliente = _clienteservice.GetAll();

            return cliente.ToList();
        }

        /// <summary>
        /// Filtrar los Cliente por ID
        /// </summary>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetClienteByID(int ID)
        {
            try
            {
                var cliente = _clienteservice.GetClienteByID(ID);

                return Ok(cliente);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Filtrar los Cliente por Dni
        /// </summary>
        [HttpGet("dni")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetClienteByDni(int Dni)
        {
            try
            {
                var cliente = _clienteservice.GetClienteByDni(Dni);

                if (cliente != null)
                {
                    return Ok(cliente);
                }
                else
                {
                    return NotFound("Cliente inexistente");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Filtrar los Cliente por Numero de Socio
        /// </summary>
        [HttpGet("guid")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetClienteByNroSocio(Guid nroSocio)
        {
            try
            {
                var cliente = _clienteservice.GetClienteByNroSocio(nroSocio);

                if (cliente != null)
                {
                    return Ok(cliente);
                }
                else
                {
                    return NotFound("Cliente inexistente");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Crear Cliente
        /// </summary>
        [HttpPost("create")]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CreateCliente([FromForm] ClienteDto cliente)
        {
            try
            {
                var existe = _clienteservice.GetClienteByDni(cliente.Dni);

                if (existe == null)
                {
                    var clienteEntity = _clienteservice.CreateCliente(cliente);

                    if (clienteEntity != null)
                    {
                        var alquilerCreado = _mapper.Map<ClienteDto>(clienteEntity);
                        return new JsonResult(alquilerCreado) { StatusCode = 201 };
                    }
                    return BadRequest();
                }
                else
                {
                    return BadRequest("Cliente existente");
                }                           
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Eliminar Cliente 
        /// </summary>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCliente(int ID)
        {
            try
            {
                var cliente = _clienteservice.GetClienteByID(ID);

                if (cliente == null)
                {
                    return NotFound();
                }

                _clienteservice.DeleteCliente(cliente);

                return Ok("Se ha eliminado el cliente exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
