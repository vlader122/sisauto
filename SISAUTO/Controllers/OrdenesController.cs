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
    public class OrdenesController : ControllerBase
    {
        private readonly OrdenesService _ordenesService;
        public OrdenesController(OrdenesService ordenesService)
        {
            _ordenesService = ordenesService;
        }
        // GET: api/<OrdenesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordenes>>> Get()
        {
            return Ok(await _ordenesService.GetAll());
        }

        // GET api/<OrdenesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordenes>> GetById(int id)
        {
            return Ok(await _ordenesService.GetById(id));
        }

        // POST api/<OrdenesController>
        [HttpPost]
        public async Task<IActionResult> Post(Ordenes pais)
        {
            return Ok(await _ordenesService.Create(pais));
        }

        // PUT api/<OrdenesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Ordenes pais)
        {
            return Ok(await _ordenesService.Update(pais));
        }

        // DELETE api/<OrdenesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ordenesService.Delete(id);
            return Ok("{ message: Deleted }");
        }
    }
}
