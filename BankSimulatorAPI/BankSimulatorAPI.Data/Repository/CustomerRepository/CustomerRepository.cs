using BankSimulatorAPI.Data.DBContext;
using BankSimulatorAPI.Data.Domain;
using BankSimulatorAPI.Data.Repository.BaseRepository;
using System;
using System.Collections.Generic;
namespace BankSimulatorAPI.Data.Repository.CustomerRepository;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(SimDbContext dbContext) : base(dbContext)
    {
    }
}
