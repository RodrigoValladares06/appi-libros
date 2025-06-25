using Microsoft.AspNetCore.Mvc;
using ApiLibros.Models;
using ApiLibros.Data;

namespace ApiLibros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(LibroRepositorio.ObtenerTodos());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var libro = LibroRepositorio.ObtenerPorId(id);
            if (libro == null) return NotFound();
            return Ok(libro);
        }

        [HttpPost]
        public IActionResult Post(Libro libro)
        {
            LibroRepositorio.Agregar(libro);
            return CreatedAtAction(nameof(Get), new { id = libro.Id }, libro);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Libro libro)
        {
            if (id != libro.Id) return BadRequest();
            LibroRepositorio.Actualizar(libro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            LibroRepositorio.Eliminar(id);
            return NoContent();
        }
    }
}
