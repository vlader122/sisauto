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
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _clientesService;
        public ClientesController(ClientesService clientesService)
        {
            _clientesService = clientesService;
        }
        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> Get()
        {
            return Ok(await _clientesService.GetAll());
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetById(int id)
        {
            return Ok(await _clientesService.GetById(id));
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<IActionResult> Post(Clientes pais)
        {
            return Ok(await _clientesService.Create(pais));
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Clientes pais)
        {
            return Ok(await _clientesService.Update(pais));
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientesService.Delete(id);
            return Ok("{ message: Deleted }");
        }
    }
}
