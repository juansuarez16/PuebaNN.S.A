using PruebaNN.S.A.Application.ViewModels;
using PruebaNN.S.A.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.Service.Interfaces
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> GetAllEmployees();
        Task<Empleado> GetEmployeeById(int id);
        Task<Empleado> CreateEmployee(RequestEmpleado datosEmpleado);
        Task<Empleado> UpdateEmployee(int id, Empleado empleado);
        Task DeleteEmployee(int id);
    }
}
