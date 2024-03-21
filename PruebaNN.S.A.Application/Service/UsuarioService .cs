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
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IRepository<Usuarios> _usuarioRepository;

        public UsuarioService(IUnitOfWork unitOfWork, IRepository<Usuarios> usuarioRepository) : base(unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuarios>> GetAllUsuarios()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuarios> GetUsuarioById(int id)
        {
            return await _usuarioRepository.GetAsync(id);
        }

        public async Task<Usuarios> CreateUsuario(Usuarios usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
            await UnitOfWork.SaveChangeAsync();
            return usuario;
        }

        public async Task UpdateUsuario(int id, Usuarios usuario)
        {
            usuario.Id = id;
            await _usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteUsuario(int id)
        {
            await _usuarioRepository.DeleteAsync(await GetUsuarioById(id));
        }
    }
}
