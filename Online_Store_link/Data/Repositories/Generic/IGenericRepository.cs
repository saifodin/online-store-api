namespace Online_Store_link.Data.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    List<TEntity> GetAll();
    TEntity? GetById(Guid id);
    void Update(TEntity entity);
    void Add(TEntity entity);
    bool Delete(Guid id);
    bool SaveChanges();
    int GetCount();
}
