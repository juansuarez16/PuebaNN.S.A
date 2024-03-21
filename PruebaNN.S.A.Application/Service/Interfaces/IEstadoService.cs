using PruebaNN.S.A.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.Service.Interfaces
{
    public interface IEstadoService
    {
        Task<IEnumerable<Estados>> GetAllEstados();
        Task<Estados> GetEstadoById(int id);
        Task CreateEstado(Estados estado);
        Task UpdateEstado(int id, Estados estado);
        Task DeleteEstado(int id);
    }
}
