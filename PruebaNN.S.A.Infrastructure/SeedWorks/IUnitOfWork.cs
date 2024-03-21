using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Infrastructure.SeedWorks
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync();
        Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task<TResult>> func);
    }
}
