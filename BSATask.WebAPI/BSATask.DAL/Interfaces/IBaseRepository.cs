namespace BSATask.DAL.Interfaces
{
    public interface IBaseRepository
    {
        void Delete<T>(int id) where T : class, DAL.IEntityBase, new();

        IEnumerable<T> GetAll<T>() where T : class, DAL.IEntityBase, new();

        T Insert<T>(T entity) where T : class, IEntityBase, new();

        void Update<T>(T entity) where T : class, DAL.IEntityBase, new();

        T GetById<T>(int id) where T : class, DAL.IEntityBase, new();
    }
}
