using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Repositories;

namespace Data.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private IAccountRepository _accountRepository;
        private IContactRepository _contactRepository;
        private IIncidentRepository _incidentRepository;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAccountRepository AccountRepository => 
            _accountRepository ??= new AccountRepository(_dbContext);

        public IContactRepository ContactRepository =>
            _contactRepository??= new ContactRepository(_dbContext);

        public IIncidentRepository IncidentRepository =>
            _incidentRepository ??= new IncidentRepository(_dbContext);

        public async Task SaveAsync()
        {
           await _dbContext.SaveChangesAsync();
        }
    }
}
