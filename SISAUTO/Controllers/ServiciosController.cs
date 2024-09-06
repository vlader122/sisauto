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
    public class ServiciosController : ControllerBase
    {
        private readonly ServiciosService _serviciosService;
        public ServiciosController(ServiciosService serviciosService)
        {
            _serviciosService = serviciosService;
        }
        // GET: api/<ServiciosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicios>>> Get()
        {
            return Ok(await _serviciosService.GetAll());
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicios>> GetById(int id)
        {
            return Ok(await _serviciosService.GetById(id));
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public async Task<IActionResult> Post(Servicios pais)
        {
            return Ok(await _serviciosService.Create(pais));
        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Servicios pais)
        {
            return Ok(await _serviciosService.Update(pais));
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviciosService.Delete(id);
            return Ok("{ message: Deleted }");
        }
    }
}
