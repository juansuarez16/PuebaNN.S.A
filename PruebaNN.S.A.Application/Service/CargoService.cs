using PruebaNN.S.A.Application.SeedWorks;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Domain.Entities;
using PruebaNN.S.A.Infrastructure.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.Service
{
    public class CargoService : BaseService, ICargoService
    {
        private readonly IRepository<Cargo> _cargoRepository;

        public CargoService(IUnitOfWork unitOfWork, IRepository<Cargo> cargoRepository) : base(unitOfWork)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<IEnumerable<Cargo>> GetAllCargos()
        {
            return await _cargoRepository.GetAllAsync();
        }

        public async Task<Cargo> GetCargoById(int id)
        {
            return await _cargoRepository.GetAsync(id);
        }

        public async Task<Cargo> CreateCargo(Cargo cargo)
        {
            await _cargoRepository.AddAsync(cargo);
            await UnitOfWork.SaveChangeAsync();
            return cargo;
        }

        public async Task<Cargo> UpdateCargo(int id, Cargo cargo)
        {
            var existingCargo = await GetCargoById(id);
            if (existingCargo == null)
            {
                // Manejar la situación en la que el cargo no existe
                return null;
            }

            existingCargo.nombre = cargo.nombre;

            await _cargoRepository.UpdateAsync(existingCargo);
            await UnitOfWork.SaveChangeAsync();
            return existingCargo;
        }

        public async Task DeleteCargo(int id)
        {
            await _cargoRepository.DeleteAsync(await GetCargoById(id));
            await UnitOfWork.SaveChangeAsync();
        }
    }
}
