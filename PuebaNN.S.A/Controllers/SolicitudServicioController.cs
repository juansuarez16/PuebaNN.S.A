using Microsoft.AspNetCore.Mvc;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Domain.Entities;

namespace PuebaNN.S.A.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudServicioController : ControllerBase
    {
        private readonly ISolicitudServicioService _solicitudServicioService;

        public SolicitudServicioController(ISolicitudServicioService solicitudServicioService)
        {
            _solicitudServicioService = solicitudServicioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var solicitudesServicio = await _solicitudServicioService.GetAllSolicitudesServicio();
            return Ok(solicitudesServicio);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var solicitudServicio = await _solicitudServicioService.GetSolicitudServicioById(id);
            if (solicitudServicio == null)
                return NotFound();
            return Ok(solicitudServicio);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SolicitudServicio solicitudServicio)
        {
            await _solicitudServicioService.CreateSolicitudServicio(solicitudServicio);
            return CreatedAtAction(nameof(Get), new { id = solicitudServicio.Id }, solicitudServicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SolicitudServicio solicitudServicio)
        {
            if (id != solicitudServicio.Id)
                return BadRequest();

            await _solicitudServicioService.UpdateSolicitudServicio(id, solicitudServicio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _solicitudServicioService.DeleteSolicitudServicio(id);
            return NoContent();
        }
    }
}
