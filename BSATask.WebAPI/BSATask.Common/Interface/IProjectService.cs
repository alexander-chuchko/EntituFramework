
using BSATask.Common.DTO;
using BSATask.DAL.Entities;

namespace BSATask.Common.Interface
{
    public interface IProjectService
    {
        IEnumerable<DTO.ProjectDTO> GetProjects();
        ProjectDTO GetProjectById(int id);

        ProjectDTO AddProject(ProjectDTO projectDTO);

        void UpdateProject(ProjectDTO projectDTO);

        void DeleteProject(int id);
    }
}
