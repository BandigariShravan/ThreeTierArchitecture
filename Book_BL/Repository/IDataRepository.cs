namespace Book_BL.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();//represents a collection of objects that can be enumerated (i.e., accessed one at a time).
        TEntity Get(int id);
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
       
    }
}