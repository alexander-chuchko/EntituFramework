using BSATask.DAL.Context;
using BSATask.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BSATask.DAL.Services.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly BSATaskContext _bSATaskContext;
        public BaseRepository(BSATaskContext bSATaskContext)
        {
            _bSATaskContext = bSATaskContext;   
        }
        public void Delete<T>(int id) where T : class, IEntityBase, new()
        {
            var entity = new T { Id = id };
            _bSATaskContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : class, IEntityBase, new()
        {
            return _bSATaskContext.Set<T>().ToList();
        }

        public T Insert<T>(T entity) where T : class, IEntityBase, new()
        {
            _bSATaskContext.Set<T>().Add(entity);
            return entity;
        }

        public T GetById<T>(int id) where T : class, IEntityBase, new()
        {
            return _bSATaskContext.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void Update<T>(T entity) where T : class, IEntityBase, new()
        {
            _bSATaskContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
