using PruebaNN.S.A.Application.SeedWorks;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Domain.Entities;
using PruebaNN.S.A.Infrastructure.SeedWorks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.Service
{
    public class ServicioService : BaseService, IServicioService
    {
        private readonly IRepository<Servicio> _servicioRepository;

        public ServicioService(IUnitOfWork unitOfWork, IRepository<Servicio> servicioRepository) : base(unitOfWork)
        {
            _servicioRepository = servicioRepository;
        }

        public async Task<IEnumerable<Servicio>> GetAllServicio()
        {
            return await _servicioRepository.GetAllAsync();
        }

        public async Task<Servicio> GetServicioById(int id)
        {
            return await _servicioRepository.GetAsync(id);
        }

        public async Task CreateServicio(Servicio servicio)
        {
            await _servicioRepository.AddAsync(servicio);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task UpdateServicio(int id, Servicio servicio)
        {
            servicio.Id = id;
            await _servicioRepository.UpdateAsync(servicio);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task DeleteServicio(int id)
        {
            await _servicioRepository.DeleteAsync(await GetServicioById(id));
            await UnitOfWork.SaveChangeAsync();
        }
    }
}
