using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleOrdenesController : ControllerBase
    {
        private readonly DetalleOrdenesService _detalleOrdenesService;
        public DetalleOrdenesController(DetalleOrdenesService detalleOrdenesService)
        {
            _detalleOrdenesService = detalleOrdenesService;
        }
        // GET: api/<DetalleOrdenesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleOrdenes>>> Get()
        {
            return Ok(await _detalleOrdenesService.GetAll());
        }

        // GET api/<DetalleOrdenesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleOrdenes>> GetById(int id)
        {
            return Ok(await _detalleOrdenesService.GetById(id));
        }

        // POST api/<DetalleOrdenesController>
        [HttpPost]
        public async Task<IActionResult> Post(DetalleOrdenes pais)
        {
            return Ok(await _detalleOrdenesService.Create(pais));
        }

        // PUT api/<DetalleOrdenesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(DetalleOrdenes pais)
        {
            return Ok(await _detalleOrdenesService.Update(pais));
        }

        // DELETE api/<DetalleOrdenesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _detalleOrdenesService.Delete(id);
            return Ok("{ message: Deleted }");
        }
    }
}
