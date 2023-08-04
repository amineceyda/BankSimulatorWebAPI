using BankSimulatorAPI.Base.BaseModel;
using BankSimulatorAPI.Data.DBContext;
using System.ComponentModel.DataAnnotations;

namespace BankSimulatorAPI.Data.Repository.BaseRepository;

public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : BaseModel
{
    private readonly SimDbContext _dbContext;
    public GenericRepository(SimDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
    public void Delete(Entity entity)
    {
        _dbContext.Set<Entity>().Remove(entity);

    }

    public void DeleteById(int id)
    {
        var entity = _dbContext.Set<Entity>().Find(id);
        Delete(entity);
    }

    public List<Entity> GetAll()
    {
        return _dbContext.Set<Entity>().ToList();
    }

    public IQueryable<Entity> GetAllAsQueryable()
    {
        return _dbContext.Set<Entity>().AsQueryable();//Sorgulanabilir
    }

    public Entity GetById(int id)
    {
        var entity = _dbContext.Set<Entity>().Find(id);
        return entity;
    }

    public void Insert(Entity entity)
    {
        entity.InsertDate = DateTime.Now;
        entity.InsertUser = "simadmin@pay.com";
        _dbContext.Set<Entity>().Add(entity);
    }

    public void Update(Entity entity)
    {
        _dbContext.Set<Entity>().Update(entity);
    }
}
