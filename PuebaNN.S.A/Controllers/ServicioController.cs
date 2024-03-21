using Microsoft.AspNetCore.Mvc;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Domain.Entities;

namespace PuebaNN.S.A.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;

        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var servicios = await _servicioService.GetAllServicio();
            return Ok(servicios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var servicio = await _servicioService.GetServicioById(id);
            if (servicio == null)
                return NotFound();
            return Ok(servicio);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Servicio servicio)
        {
            await _servicioService.CreateServicio(servicio);
            return CreatedAtAction(nameof(Get), new { id = servicio.Id }, servicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Servicio servicio)
        {
            if (id != servicio.Id)
                return BadRequest();

            await _servicioService.UpdateServicio(id, servicio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _servicioService.DeleteServicio(id);
            return NoContent();
        }
    }
}
