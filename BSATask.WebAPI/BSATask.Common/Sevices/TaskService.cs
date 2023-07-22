using AutoMapper;
using BSATask.Common.DTO;
using BSATask.Common.Interface;
using BSATask.DAL.Entities;
using BSATask.DAL.Interfaces;
using Newtonsoft.Json;

namespace BSATask.Common.Sevices
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<TaskDTO> GetTasks()
        {
            IEnumerable<TaskDTO> tasksDTO = null;

            var tasks = _unitOfWork.Tasks.GetAll<DAL.Entities.Task>();
            tasksDTO = _mapper.Map<IEnumerable<TaskDTO>>(tasks);

            return tasksDTO;
        }

        public TaskDTO GetTaskById(int id)
        {
            TaskDTO taskDTO = null;

            var task = _unitOfWork.Tasks.GetAll<DAL.Entities.Task>().FirstOrDefault(v => v.Id == id);
            if (task != null)
            {
                taskDTO = _mapper.Map<TaskDTO>(task);
            }

            return taskDTO;
        }

        public TaskDTO AddTask(TaskDTO taskDTO)
        {
            if (taskDTO != null)
            {
                var task = _mapper.Map<DAL.Entities.Task>(taskDTO);
                _unitOfWork.Tasks.Insert<DAL.Entities.Task>(task);
                _unitOfWork.Commit();

                var lastAddedTask = _unitOfWork.Teams.GetAll<DAL.Entities.Task>().ToList().LastOrDefault();
                return _mapper.Map<TaskDTO>(lastAddedTask);
            }
            return null;
        }

        public void UpdateTask(TaskDTO taskDTO)
        {
            var foundTask = _unitOfWork.Tasks.GetAll<DAL.Entities.Task>().FirstOrDefault(v => v.Id == taskDTO.Id);
            if (foundTask != null)
            {
                var task = _mapper.Map<DAL.Entities.Task>(taskDTO);
                _unitOfWork.Tasks.Update<DAL.Entities.Task>(task);
                _unitOfWork.Commit();
            }
        }

        public void DeleteTask(int id)
        {
            var task = _unitOfWork.Tasks.GetAll<DAL.Entities.Task>().FirstOrDefault(v => v.Id == id);
            if (task != null)
            {
                _unitOfWork.Tasks.Delete<DAL.Entities.Task>(id);
                _unitOfWork.Commit();
            }
        }
    }
}

/*








 
 */
