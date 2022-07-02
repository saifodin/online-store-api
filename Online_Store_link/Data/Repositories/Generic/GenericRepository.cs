using Online_Store_link.Data.Context;

namespace Online_Store_link.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly OnlineStoreContext context;

    public GenericRepository(OnlineStoreContext context)
    {
        this.context = context;
    }

    public List<TEntity> GetAll()
    {
        return context.Set<TEntity>().ToList();
    }

    public TEntity? GetById(Guid id)
    {
        return context.Set<TEntity>().Find(id);
    }

    public void Add(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
    }

    public bool Delete(Guid id)
    {
        var entityToDelete = GetById(id);
        if (entityToDelete is not null)
        {
            context.Set<TEntity>().Remove(entityToDelete);
            return true;
        }
        return false;
    }

    public void Update(TEntity entity)
    {

    }

    public bool SaveChanges()
    {
        return context.SaveChanges() > 0;
    }

    public int GetCount()
    {
        return context.Set<TEntity>().Count();
    }
}
