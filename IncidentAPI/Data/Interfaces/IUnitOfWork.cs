using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        IContactRepository ContactRepository { get; }
        IIncidentRepository IncidentRepository { get; }
        Task SaveAsync();
    }
}
