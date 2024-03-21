using Microsoft.AspNetCore.Mvc;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Application.ViewModels;
using PruebaNN.S.A.Domain.Entities;
using PruebaNN.S.A.Infrastructure.SeedWorks;

namespace PuebaNN.S.A.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController: ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var empleados = await _empleadoService.GetAllEmployees();
            return Ok(empleados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var empleado = await _empleadoService.GetEmployeeById(id);
            if (empleado == null)
                return NotFound();
            return Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestEmpleado empleado)
        {
            await _empleadoService.CreateEmployee(empleado);
            return CreatedAtAction(nameof(Get), new { id = empleado.empleado.Id }, empleado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.Id)
                return BadRequest();

            await _empleadoService.UpdateEmployee(id, empleado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            await _empleadoService.DeleteEmployee(id);
            return NoContent();
        }
    }
}
