using PruebaNN.S.A.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.Service.Interfaces
{
    public interface ICargoService
    {
        Task<IEnumerable<Cargo>> GetAllCargos();
        Task<Cargo> GetCargoById(int id);
        Task<Cargo> CreateCargo(Cargo cargo);
        Task<Cargo> UpdateCargo(int id, Cargo cargo);
        Task DeleteCargo(int id);
    }
}
