using Microsoft.AspNetCore.Mvc;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Domain.Entities;

namespace PuebaNN.S.A.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _estadoService;

        public EstadoController(IEstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var estados = await _estadoService.GetAllEstados();
            return Ok(estados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var estado = await _estadoService.GetEstadoById(id);
            if (estado == null)
                return NotFound();
            return Ok(estado);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Estados estado)
        {
            await _estadoService.CreateEstado(estado);
            return CreatedAtAction(nameof(Get), new { id = estado.Id }, estado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Estados estado)
        {
            if (id != estado.Id)
                return BadRequest();

            await _estadoService.UpdateEstado(id, estado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _estadoService.DeleteEstado(id);
            return NoContent();
        }
    }
}
