using PruebaNN.S.A.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.Service.Interfaces
{
    public interface ISolicitudServicioService
    {
        Task<IEnumerable<SolicitudServicio>> GetAllSolicitudesServicio();
        Task<SolicitudServicio> GetSolicitudServicioById(int id);
        Task CreateSolicitudServicio(SolicitudServicio solicitudServicio);
        Task UpdateSolicitudServicio(int id, SolicitudServicio solicitudServicio);
        Task DeleteSolicitudServicio(int id);
    }
}
