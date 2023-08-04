using BankSimulatorAPI.Base.Response;
using BankSimulatorAPI.Data.Domain;
using BankSimulatorAPI.Data.Repository.AccountRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSimulatorAPI.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _repository;

    public AccountController(IAccountRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ApiResponse<List<Account>> GetAll()
    {
        var entityList = _repository.GetAll();
        return new ApiResponse<List<Account>>(entityList);
    }

    [HttpGet("{id}")]
    public ApiResponse<Account> Get(int id)
    {
        var entity = _repository.GetById(id);
        return new ApiResponse<Account>(entity);
    }


    [HttpPost]
    public ApiResponse Post([FromBody] Account request)
    {
        _repository.Insert(request);
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] Account request)
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
