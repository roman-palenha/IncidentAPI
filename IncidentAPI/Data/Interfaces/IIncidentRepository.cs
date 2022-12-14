using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IIncidentRepository : IRepository<Incident>
    {
        Task<Incident> GetByName(string name);
        Task DeleteByName(string name);
    }
}
