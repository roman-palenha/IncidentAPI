using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTO;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IIncidentService
    {
        Task<IEnumerable<Incident>> GetAllAsync();

        Task<Incident> GetByIdAsync(Guid id);

        Task AddAsync(IncidentDto dto);

        Task UpdateAsync(IncidentUpdateDto dto);

        Task DeleteAsync(string name);
    }
}
