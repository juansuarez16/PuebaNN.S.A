using PruebaNN.S.A.Application.SeedWorks;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Application.ViewModels;
using PruebaNN.S.A.Domain.Entities;
using PruebaNN.S.A.Infrastructure;
using PruebaNN.S.A.Infrastructure.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.Service
{
    public class EmpleadosService : BaseService, IEmpleadoService
    {
        private readonly IRepository<Empleado> _empleadoRepository;
        private readonly IRepository<Cargo> _cargoRepository;
        private readonly IUsuarioService _usuarioService;

        public EmpleadosService(IUnitOfWork unitOfWork, IRepository<Empleado> empleadoRepository, IRepository<Cargo> cargoRepository,IUsuarioService usuarioService) : base(unitOfWork)
        {
            _empleadoRepository = empleadoRepository;
            _cargoRepository = cargoRepository;
            _usuarioService = usuarioService;
        }

        public async Task<IEnumerable<Empleado>> GetAllEmployees()
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            var empleadosData = empleados.Select(empleado => new Empleado
            {
                cedula = empleado.cedula,
                nombre = empleado.nombre,
                fechaIngreso = empleado.fechaIngreso,                
                
            });
            return empleados; 
        }

        public async Task<Empleado> GetEmployeeById(int id)
        {
            return await _empleadoRepository.GetAsync(id);
        }

        public async Task<Empleado> CreateEmployee(RequestEmpleado datosEmpleado)
        {
            // Crear el usuario primero
            Usuarios datosUser= new Usuarios() {
                CreateDate = datosEmpleado.usuario.CreateDate,
                UpdateDate = datosEmpleado.usuario.UpdateDate,
                usuario = datosEmpleado.usuario.usuario,
                contrasena = datosEmpleado.usuario.contrasena
            };
            var nuevoUsuario = await _usuarioService.CreateUsuario(datosUser);

            Empleado empleado = new Empleado();
            empleado.CreateDate = datosEmpleado.empleado.CreateDate;
            empleado.UpdateDate = datosEmpleado.empleado.UpdateDate;
            empleado.nombre = datosEmpleado.empleado.nombre;
            empleado.cedula = datosEmpleado.empleado.cedula;
            empleado.rutaFoto = datosEmpleado.empleado.rutaFoto;
            empleado.usuarioId = (int)nuevoUsuario.Id;
            empleado.fechaIngreso = datosEmpleado.empleado.fechaIngreso;
            empleado.cargoId = datosEmpleado.empleado.cargoId;
            empleado.rolId = datosEmpleado.rol;
            await _empleadoRepository.AddAsync(empleado);
            await UnitOfWork.SaveChangeAsync();
            return empleado;
        }

        public async Task<Empleado> UpdateEmployee(int id, Empleado empleado)
        {
            var existingEmployee = await GetEmployeeById(id);
            if (existingEmployee == null)
            {
                // Manejar la situación en la que el empleado no existe
                return null;
            }

            existingEmployee.cedula = empleado.cedula;
            existingEmployee.nombre = empleado.nombre;
            existingEmployee.rutaFoto = empleado.rutaFoto;
            existingEmployee.fechaIngreso = empleado.fechaIngreso;

            await _empleadoRepository.UpdateAsync(existingEmployee);
            await UnitOfWork.SaveChangeAsync();
            return existingEmployee;
        }

        public async Task DeleteEmployee(int id)
        {
            await _empleadoRepository.DeleteAsync(await GetEmployeeById(id));
            await UnitOfWork.SaveChangeAsync();
        }
    }
}
