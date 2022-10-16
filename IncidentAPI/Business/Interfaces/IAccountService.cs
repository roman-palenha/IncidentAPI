using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAsync();

        Task<Account> GetByIdAsync(Guid id);

        Task AddAsync(AccountDto dto);

        Task UpdateAsync(AccountDto dto);

        Task DeleteAsync(Guid id);
    }
}
