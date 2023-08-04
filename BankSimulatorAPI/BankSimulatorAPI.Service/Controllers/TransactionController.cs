using BankSimulatorAPI.Base.Response;
using BankSimulatorAPI.Data.Domain;
using BankSimulatorAPI.Data.Repository.TransactionRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSimulatorAPI.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ITransactionRepository _repository;

    public TransactionController(ITransactionRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ApiResponse<List<Transaction>> GetAll()
    {
        var entityList = _repository.GetAll();
        return new ApiResponse<List<Transaction>>(entityList);
    }

    [HttpGet("{id}")]
    public ApiResponse<Transaction> Get(int id)
    {
        var entity = _repository.GetById(id);
        return new ApiResponse<Transaction>(entity);
    }


    [HttpPost]
    public ApiResponse Post([FromBody] Transaction request)
    {
        _repository.Insert(request);
        return new ApiResponse();
    }

    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] Transaction request)
    {
        request.Id = id;
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
