using Microsoft.AspNetCore.Mvc;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Domain.Entities;

namespace PuebaNN.S.A.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cargos = await _cargoService.GetAllCargos();
            return Ok(cargos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cargo = await _cargoService.GetCargoById(id);
            if (cargo == null)
                return NotFound();
            return Ok(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cargo cargo)
        {
            await _cargoService.CreateCargo(cargo);
            return CreatedAtAction(nameof(Get), new { id = cargo.Id }, cargo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cargo cargo)
        {
            if (id != cargo.Id)
                return BadRequest();

            await _cargoService.UpdateCargo(id, cargo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cargoService.DeleteCargo(id);
            return NoContent();
        }
    }
}
