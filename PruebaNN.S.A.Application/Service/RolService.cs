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
    public class RolService : BaseService, IRolService
    {
        private readonly IRepository<Rol> _rolRepository;

        public RolService(IUnitOfWork unitOfWork, IRepository<Rol> rolRepository) : base(unitOfWork)
        {
            _rolRepository = rolRepository;
        }

        public async Task<IEnumerable<Rol>> GetAllRoles()
        {
            return await _rolRepository.GetAllAsync();
        }

        public async Task<Rol> GetRolById(int id)
        {
            return await _rolRepository.GetAsync(id);
        }

        public async Task CreateRol(Rol rol)
        {
            await _rolRepository.AddAsync(rol);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task UpdateRol(int id, Rol rol)
        {
            rol.Id = id;
            await _rolRepository.UpdateAsync(rol);
            await UnitOfWork.SaveChangeAsync();
        }

        public async Task DeleteRol(int id)
        {
            await _rolRepository.DeleteAsync(await GetRolById(id));
            await UnitOfWork.SaveChangeAsync();
        }
    }
}
