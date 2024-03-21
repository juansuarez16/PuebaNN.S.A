using PruebaNN.S.A.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.Service.Interfaces
{
    public interface IRolService
    {
        Task<IEnumerable<Rol>> GetAllRoles();
        Task<Rol> GetRolById(int id);
        Task CreateRol(Rol rol);
        Task UpdateRol(int id, Rol rol);
        Task DeleteRol(int id);
    }
}
