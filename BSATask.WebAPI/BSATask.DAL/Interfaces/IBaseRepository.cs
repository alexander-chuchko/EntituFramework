namespace BSATask.DAL.Interfaces
{
    public interface IBaseRepository
    {
        void Delete<T>(int id) where T : DAL.IEntityBase, new();

        IEnumerable<T> GetAll<T>() where T : DAL.IEntityBase, new();

        void Insert<T>(T entity) where T : DAL.IEntityBase, new();

        void Update<T>(T entity) where T : DAL.IEntityBase, new();

        T GetById<T>(int id) where T : DAL.IEntityBase, new();
    }
}
