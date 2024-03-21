using PruebaNN.S.A.Application.SeedWorks;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Domain.Entities;
using PruebaNN.S.A.Infrastructure.SeedWorks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.Service
{
    public class EstadoService : BaseService, IEstadoService
    {
        private readonly IRepository<Estados> _estadoRepository;

        public EstadoService(IUnitOfWork unitOfWork,IRepository<Estados> estadoRepository) : base(unitOfWork)
        {
            _estadoRepository = estadoRepository;
        }

        public async Task<IEnumerable<Estados>> GetAllEstados()
        {
            return await _estadoRepository.GetAllAsync();
        }

        public async Task<Estados> GetEstadoById(int id)
        {
            return await _estadoRepository.GetAsync(id);
        }

        public async Task CreateEstado(Estados estado)
        {
            await _estadoRepository.AddAsync(estado);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task UpdateEstado(int id, Estados estado)
        {
            estado.Id = id;
            await _estadoRepository.UpdateAsync(estado);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task DeleteEstado(int id)
        {
            await _estadoRepository.UpdateAsync(await GetEstadoById(id));
            await UnitOfWork.SaveChangeAsync();
        }
    }
}
