using BSATask.DAL.Interfaces;
using BSATask.DAL.Services;
using BSATask.DAL;
using System.Reflection;
using BSATask.Common.Interface;
using BSATask.Common.Sevices;
using BSATask.Common.MappingProfiles;


namespace BSATask.WebAPI.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<IMock, Mock>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ContextEntity>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IUserService, UserService>();
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ProjectProfile>();
                cfg.AddProfile<TeamProfile>();
                cfg.AddProfile<TaskProfile>();
                cfg.AddProfile<UserProfile>();
            },
            Assembly.GetExecutingAssembly());
        }
    }
}
