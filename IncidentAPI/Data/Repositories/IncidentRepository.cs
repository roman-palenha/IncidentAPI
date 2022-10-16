using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class IncidentRepository : Repository<Incident>, IIncidentRepository
    {
        public IncidentRepository(AppDbContext dbContext)
            : base(dbContext)
        {
            
        }

        public async Task DeleteByName(string name)
        {
            var entity = await GetByName(name);
            Delete(entity);
        }

        public async Task<Incident> GetByName(string name)
        {
            return await DbContext.Set<Incident>().FirstOrDefaultAsync(x => x.Name.Equals(name));
        }
    }
}
