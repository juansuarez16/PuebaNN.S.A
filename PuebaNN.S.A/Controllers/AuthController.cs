using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Linq;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Application.ViewModels;
using PruebaNN.S.A.Domain.Entities;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUsuarioService _userService;
    private readonly IEmpleadoService _empleadoService;

    public AuthController(IUsuarioService userService, IEmpleadoService empleadoService)
    {
        _userService = userService;
        _empleadoService = empleadoService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var user = await _userService.GetAllUsuarios();
        var usuario = user.FirstOrDefault(u => u.usuario == request.usuario);

        // Verificar si se encontró un usuario con el nombre de usuario proporcionado
        if (usuario == null)
        {
            return Unauthorized(new { message = "Usuario no encontrado" });
        }

        // Verificar si la contraseña proporcionada coincide con la contraseña del usuario encontrado
        if (usuario.contrasena != request.contrasena)
        {
            return Unauthorized(new { message = "Contraseña incorrecta" });
        }
        // Obtener el empleado asociado al usuario
        var empleadoData = await _empleadoService.GetAllEmployees();
        var empleado = empleadoData.FirstOrDefault(u => u.usuarioId == usuario.Id);
        if (empleado == null)
        {
            // Si no se encuentra un empleado asociado al usuario, retornar un error
            return NotFound(new { message = "Empleado no encontrado" });
        }

        return Ok(new { message = "Inicio de sesión exitoso",success=true, empleado });
    }
}
