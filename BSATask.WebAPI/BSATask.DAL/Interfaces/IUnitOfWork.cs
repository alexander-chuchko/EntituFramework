using BSATask.DAL.Services.Repositories;

namespace BSATask.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        UsersRepository Users
        {
            get;
        }
        TasksRepository Tasks
        {
            get;
        }
        ProjectsRepository Projects
        {
            get;
        }
        TeamsRepository Teams
        {
            get;
        }
    }
}
