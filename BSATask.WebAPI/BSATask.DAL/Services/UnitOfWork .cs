using BSATask.DAL.Interfaces;
using BSATask.DAL.Services.Repositories;

namespace BSATask.DAL.Services
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private ContextEntity _contextEntity;
        private UsersRepository _users;
        private TasksRepository _tasks;
        private ProjectsRepository _projects;
        private TeamsRepository _teams;
        private bool disposed = false;

        public UnitOfWork(ContextEntity contextEntity)
        {
            _contextEntity = contextEntity;
        }

        public UsersRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UsersRepository(_contextEntity);
                }
                return _users;
            }
        }

        public TasksRepository Tasks
        {
            get
            {
                if (_tasks == null)
                {
                    _tasks = new TasksRepository(_contextEntity);
                }
                return _tasks;
            }
        }

        public ProjectsRepository Projects
        {
            get
            {
                if (_projects == null)
                {
                    _projects = new ProjectsRepository(_contextEntity);
                }
                return _projects;
            }
        }

        public TeamsRepository Teams
        {
            get
            {
                if (_teams == null)
                {
                    _teams = new TeamsRepository(_contextEntity);
                }
                return _teams;
            }
        }

        public void Commit()
        {
            //Write an implementation to save to a database or file
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _contextEntity.Dispose();
                }
                disposed = true;
            }
        }
    }
}
