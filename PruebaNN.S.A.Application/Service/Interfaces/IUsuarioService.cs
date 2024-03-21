using PruebaNN.S.A.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuarios>> GetAllUsuarios();
        Task<Usuarios> GetUsuarioById(int id);
        Task<Usuarios> CreateUsuario(Usuarios usuario);
        Task UpdateUsuario(int id, Usuarios usuario);
        Task DeleteUsuario(int id);
    }
}
