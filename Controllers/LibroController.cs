using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBiblioteca.Domain;
using WebBiblioteca.Infraestructure.Entities;
using WebBiblioteca.Services;
using WebBiblioteca.Services.Interfaces;

namespace WebBiblioteca.Controllers
{
    [Route("api/libro")]
    [ApiController]
    public class LibroController : Controller
    {
        private readonly ILibroService _libroservice;
        private readonly IMapper _mapper;

        public LibroController(ILibroService libroService,
            IMapper mapper)
        {
            _libroservice = libroService;
            _mapper = mapper;
        }

        /// <summary>
        /// Filtrar todos los Libros 
        /// </summary>
        [HttpGet("all")]
        public List<Libro> GetAll()
        {
            var libro = _libroservice.GetAll();

            return libro.ToList();
        }

        /// <summary>
        /// Filtrar los Libros por ID
        /// </summary>
        [HttpGet("id")]
        public IActionResult GetLibroID(int ID)
        {
            var libro = _libroservice.GetLibroID(ID);

            return Json(libro);
        }

        /// <summary>
        /// Filtrar los Libros por ISBN
        /// </summary>
        [HttpGet("ISBN")]
        public IActionResult GetLibroISBN(string ISBN)
        {
            var libro = _libroservice.GetLibroISBN(ISBN);

            return Json(libro);
        }

        /// <summary>
        /// Crear Libro
        /// </summary>
        [HttpPost("create")]
        [ProducesResponseType(typeof(LibroDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult CreateLibro([FromForm] LibroDto libro)
        {
            try
            {
                //var existe = _context.Libros.Where(x => x.ISBN == libro.ISBN).FirstOrDefault();

                var existe = _libroservice.GetLibroISBN(libro.ISBN);

                if (existe == null)
                {
                    var libroEntity = _libroservice.CreateLibro(libro);

                    if (libroEntity != null)
                    {
                        var libroCreado = _mapper.Map<Libro>(libroEntity);
                        return new JsonResult(libroCreado) { StatusCode = 201 };
                    }
                    return BadRequest();
                }
                else
                {
                    _libroservice.UpdateStock(libro.ISBN, libro.Stock);

                    return Ok("Se ha actualizado el stock exitosamente");
                }                             
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Eliminar Libro 
        /// </summary>
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteLibro(int ID)
        {
            try
            {
                var libro = _libroservice.GetLibroID(ID);

                if (libro == null)
                {
                    return NotFound();
                }

                _libroservice.DeleteLibro(libro);

                return Ok("Se ha eliminado el libro exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
