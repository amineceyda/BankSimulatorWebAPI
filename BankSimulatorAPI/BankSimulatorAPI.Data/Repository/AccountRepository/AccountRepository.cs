using BankSimulatorAPI.Data.DBContext;
using BankSimulatorAPI.Data.Domain;
using BankSimulatorAPI.Data.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulatorAPI.Data.Repository.AccountRepository;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    public AccountRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
