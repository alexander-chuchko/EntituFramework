using BSATask.DAL.Interfaces;

namespace BSATask.DAL
{
    public class ContextEntity
    {
        private readonly IMock _mock;
        public Dictionary<Type, List<DAL.IEntityBase>> _container { get; set; }

        public ContextEntity(IMock mock)
        {
            _mock = mock;
            _container = new Dictionary<Type, List<DAL.IEntityBase>>();
            Initialization();
        }

        private void Initialization() 
        {
            _container.Add(typeof(DAL.Entities.Team), _mock.GetTeams().ToList().ToList<DAL.IEntityBase>());
            _container.Add(typeof(DAL.Entities.Project), _mock.GetProjects().ToList<DAL.IEntityBase>());
            _container.Add(typeof(DAL.Entities.User), _mock.GetUsers().ToList<DAL.IEntityBase>());
            _container.Add(typeof(DAL.Entities.Task), _mock.GetTasks().ToList<DAL.IEntityBase>());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
