using PruebaNN.S.A.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.Service.Interfaces
{
    public interface IServicioService
    {
        Task<IEnumerable<Servicio>> GetAllServicio();
        Task<Servicio> GetServicioById(int id);
        Task CreateServicio(Servicio solicitudServicio);
        Task UpdateServicio(int id, Servicio solicitudServicio);
        Task DeleteServicio(int id);
    }
}
