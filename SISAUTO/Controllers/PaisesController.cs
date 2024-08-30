using DB;
using DB.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SISAUTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly SisautoContext _context;
        private readonly PaisesService _paisesService;
        public PaisesController(SisautoContext context, PaisesService paisesService)
        {
            _context = context;
            _paisesService = paisesService;
        }
        // GET: api/<PaisesController>
        [HttpGet]
        public List<Paises> Get()
        {
            return _paisesService.GetAll();
        }

        // GET api/<PaisesController>/5
        [HttpGet("{id}")]
        public Paises Get(int id)
        {
            Paises pais = _context.Paises.Find(id);
            return pais;
        }

        // POST api/<PaisesController>
        [HttpPost]
        public IActionResult Post(Paises pais)
        {
            _context.Paises.Add(pais);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/<PaisesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Paises pais)
        {
            Paises paisActualizado =_context.Paises.Find(id);
            if (paisActualizado != null)
            {
                paisActualizado.Nombre = pais.Nombre;
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<PaisesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Paises paisEliminar = _context.Paises.Find(id);
            if (paisEliminar != null)
            {
                _context.Paises.Remove(paisEliminar);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
    }
}
