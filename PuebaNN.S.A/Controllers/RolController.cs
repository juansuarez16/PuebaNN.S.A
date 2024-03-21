using Microsoft.AspNetCore.Mvc;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Domain.Entities;
using System.Threading.Tasks;

namespace PuebaNN.S.A.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _rolService.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var rol = await _rolService.GetRolById(id);
            if (rol == null)
                return NotFound();
            return Ok(rol);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rol rol)
        {
            await _rolService.CreateRol(rol);
            return CreatedAtAction(nameof(Get), new { id = rol.Id }, rol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Rol rol)
        {
            if (id != rol.Id)
                return BadRequest();

            await _rolService.UpdateRol(id, rol);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rolService.DeleteRol(id);
            return NoContent();
        }
    }
}
