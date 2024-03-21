using PruebaNN.S.A.Application.SeedWorks;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Domain.Entities;
using PruebaNN.S.A.Infrastructure.SeedWorks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.Service
{
    public class SolicitudServicioService : BaseService, ISolicitudServicioService
    {
        private readonly IRepository<SolicitudServicio> _solicitudServicioRepository;

        public SolicitudServicioService(IUnitOfWork unitOfWork, IRepository<SolicitudServicio> solicitudServicioRepository) : base(unitOfWork)
        {
            _solicitudServicioRepository = solicitudServicioRepository;
        }

        public async Task<IEnumerable<SolicitudServicio>> GetAllSolicitudesServicio()
        {
            return await _solicitudServicioRepository.GetAllAsync();
        }

        public async Task<SolicitudServicio> GetSolicitudServicioById(int id)
        {
            return await _solicitudServicioRepository.GetAsync(id);
        }

        public async Task CreateSolicitudServicio(SolicitudServicio solicitudServicio)
        {
            await _solicitudServicioRepository.AddAsync(solicitudServicio);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task UpdateSolicitudServicio(int id, SolicitudServicio solicitudServicio)
        {
            solicitudServicio.Id = id;
            await _solicitudServicioRepository.UpdateAsync(solicitudServicio);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task DeleteSolicitudServicio(int id)
        {
            await _solicitudServicioRepository.DeleteAsync(await GetSolicitudServicioById(id));
            await UnitOfWork.SaveChangeAsync();
        }
    }
}
