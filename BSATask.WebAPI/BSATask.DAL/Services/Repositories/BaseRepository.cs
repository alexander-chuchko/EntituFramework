using BSATask.DAL.Interfaces;


namespace BSATask.DAL.Services.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ContextEntity _contextEntity;
        public BaseRepository(ContextEntity contextEntity)
        {
            _contextEntity = contextEntity;
        }
        public void Delete<T>(int id) where T : IEntityBase, new()
        {
            if (_contextEntity._container.ContainsKey(typeof(T)))
            {
                var foundEntity = (T)_contextEntity._container[typeof(T)].ToList()[id];
                _contextEntity._container[typeof(T)].Remove(foundEntity);
            }
        }

        public IEnumerable<T> GetAll<T>() where T : IEntityBase, new()
        {
            if (_contextEntity._container.ContainsKey(typeof(T)))
            {
                return _contextEntity._container[typeof(T)].Cast<T>();
            }

            return Enumerable.Empty<T>();
        }

        public void Insert<T>(T entity) where T : IEntityBase, new()
        {
            if (_contextEntity._container.ContainsKey(typeof(T)))
            {
                var id = GetAll<T>().ToList().Count + 1;
                entity.Id = id;
                _contextEntity._container[typeof(T)].Add(entity);
            }
        }

        public T GetById<T>(int id) where T : IEntityBase, new()
        {
            return (T)_contextEntity._container[typeof(T)].ToList()[id];
        }

        public void Update<T>(T entity) where T : IEntityBase, new()
        {
            if (_contextEntity._container.ContainsKey(typeof(T)))
            {
                var existingEntity = GetById<T>(entity.Id - 1);
                if (existingEntity != null)
                {
                    var index = _contextEntity._container[typeof(T)].IndexOf(existingEntity);
                    var res = _contextEntity._container[typeof(T)][index] = entity;
                }
            }
        }
    }
}
