using BankSimulatorAPI.Data.DBContext;
using BankSimulatorAPI.Data.Domain;
using BankSimulatorAPI.Data.Repository.BaseRepository;


namespace BankSimulatorAPI.Data.Repository.TransactionRepository;

public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
