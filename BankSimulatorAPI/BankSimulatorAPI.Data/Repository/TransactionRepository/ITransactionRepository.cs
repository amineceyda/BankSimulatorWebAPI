using BankSimulatorAPI.Data.Domain;
using BankSimulatorAPI.Data.Repository.BaseRepository;


namespace BankSimulatorAPI.Data.Repository.TransactionRepository;

public interface ITransactionRepository:IGenericRepository<Transaction>
{
}
