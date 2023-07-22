using BSATask.Common.DTO;
using BSATask.DAL.Entities;

namespace BSATask.Common.Interface
{
    public interface ITaskService
    {
        IEnumerable<DTO.TaskDTO> GetTasks();
        DTO.TaskDTO GetTaskById(int id);

        TaskDTO AddTask(TaskDTO taskDTO);
        void UpdateTask(DTO.TaskDTO taskDTO);

        void DeleteTask(int id);
    }
}
