using BankSimulatorAPI.Base.Response;
using BankSimulatorAPI.Data.Domain;
using BankSimulatorAPI.Data.Repository.CustomerRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSimulatorAPI.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository; // dependency injection

    public CustomerController(ICustomerRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public ApiResponse<List<Customer>> GetAll()
    {
        var entityList = _repository.GetAll();
        return new ApiResponse<List<Customer>>(entityList);
    }

    [HttpGet("{id}")]
    public ApiResponse<Customer> Get(int id)
    {
        var entity = _repository.GetById(id);
        return new ApiResponse<Customer>(entity);
    }


    [HttpPost]
    public ApiResponse Post([FromBody] Customer request)
    {
        _repository.Insert(request);
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] Customer request)
    {
        request.CustomerNumber = id;
        _repository.Update(request);
        return new ApiResponse();
    }


    [HttpDelete("{id}")]
    public ApiResponse Delete(int id)
    {
        _repository.DeleteById(id);
        return new ApiResponse();
    }

}
