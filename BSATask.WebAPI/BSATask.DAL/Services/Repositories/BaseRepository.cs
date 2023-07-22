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
            var entity = _bSATaskContext.Set<T>().Find(id);
            if (entity != null)
            {
                _bSATaskContext.Set<T>().Remove(entity);
            }
        }

        public IEnumerable<T> GetAll<T>() where T : class, IEntityBase, new()
        {
            return _bSATaskContext.Set<T>().ToList();
        }

        public void Insert<T>(T entity) where T : class, IEntityBase, new()
        {
            _bSATaskContext.Set<T>().Add(entity);
        }

        public T GetById<T>(int id) where T : class, IEntityBase, new()
        {
            return _bSATaskContext.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void Update<T>(T entity) where T : class, IEntityBase, new()
        {
            var existingEntity = _bSATaskContext.Set<T>().Find(entity.Id);

            if (existingEntity == null)
            {
                throw new ArgumentException($"Entity with ID {entity.Id} not found in the database.");
            }

            _bSATaskContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        }
    }
}
