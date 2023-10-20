using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebBiblioteca.Domain;
using WebBiblioteca.Infraestructure.Entities;
using WebBiblioteca.Services;
using WebBiblioteca.Services.Interfaces;
using WebBiblioteca.Utilities;

namespace WebBiblioteca.Controllers
{
    [Route("api/alquiler")]
    [ApiController]
    public class AlquilerController : Controller
    {
        private readonly IAlquilerService _alquilerservice;
        private readonly ILibroService _libroservice;
        private readonly IMapper _mapper;

        public AlquilerController(IAlquilerService alquilerService,
            IMapper mapper,
            ILibroService libroservice)
        {
            _alquilerservice = alquilerService;
            _mapper = mapper;
            _libroservice = libroservice;
        }

        /// <summary>
        /// Filtrar todos los Alquileres 
        /// </summary>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                return new JsonResult(_alquilerservice.GetAll().ToList());
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Filtrar los Alquileres por ID
        /// </summary>
        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAlquilerByID(int ID)
        {
            try
            {
                var alquiler = _alquilerservice.GetAlquilerByID(ID);

                return Ok(alquiler);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Crear Alquiler 
        /// </summary>
        [HttpPost("create")]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateAlquiler([FromForm] AlquilerDto alquiler)
        {
            try
            {
                var stock = _libroservice.GetLibroISBN(alquiler.ISBN);

                if (stock.Stock != 0)
                {
                    var alquilerEntity = _alquilerservice.CreateAlquiler(alquiler);

                    if (alquilerEntity != null)
                    {
                        var alquilerCreado = _mapper.Map<AlquilerDto>(alquilerEntity);
                        return new JsonResult(alquilerCreado) { StatusCode = 201 };
                    }
                    return BadRequest();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Eliminar Alquiler 
        /// </summary>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteAlquiler(int ID)
        {
            try
            {
                var alquiler = _alquilerservice.GetAlquilerByID(ID);

                if (alquiler == null)
                {
                    return NotFound();
                }
                    
               _alquilerservice.DeleteAlquiler(alquiler);               

                return Ok("Se ha eliminado el alquiler exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
