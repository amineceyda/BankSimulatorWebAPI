using BankSimulatorAPI.Data.Domain;
using BankSimulatorAPI.Data.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSimulatorAPI.Data.Repository.CustomerRepository;

public interface ICustomerRepository : IGenericRepository<Customer>
{
}
