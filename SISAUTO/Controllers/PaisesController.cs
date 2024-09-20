using DB;
using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SISAUTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly PaisesService _paisesService;
        public PaisesController(PaisesService paisesService)
        {
            _paisesService = paisesService;
        }
        // GET: api/<PaisesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paises>>> Get()
        {
            return Ok(await _paisesService.GetAll());
        }

        // GET api/<PaisesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paises>> GetById(int id)
        {
            return Ok(await _paisesService.GetById(id));
        }

        // POST api/<PaisesController>
        [HttpPost]
        public async Task<IActionResult> Post(Paises pais)
        {
            return Ok(await _paisesService.Create(pais));
        }

        // PUT api/<PaisesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Paises pais)
        {
            return Ok(await _paisesService.Update(pais));
        }

        // DELETE api/<PaisesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paisesService.Delete(id);
            return Ok("{ message: Deleted }");
        }
    }
}
