using BSATask.Common.Interface;
using BSATask.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;   
        }

        //api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<TaskDTO>> GetAll()
        {
            return Ok(_taskService.GetTasks());
        }

        //api/tasks/{id}
        [HttpGet("{id}")]
        public ActionResult<TaskDTO> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var task = _taskService.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        //api/tasks
        [HttpPost]
        public IActionResult Add([FromBody] TaskDTO taskDTO)
        {
            try
            {
                _taskService.AddTask(taskDTO);

                return CreatedAtRoute("GetById", new { id = taskDTO.Id }, taskDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //api/tasks/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = _taskService.GetTasks().FirstOrDefault(v => v.Id == id);

            if (task == null)
            {
                return NotFound();
            }
            if (id < 1)
            {
                return BadRequest();
            }
            _taskService.DeleteTask(id);

            return NoContent();
        }

        //api/tasks/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTeam([FromBody] TaskDTO taskDTO)
        {
            var foundTasks = _taskService.GetTasks().FirstOrDefault(t => t.Id ==taskDTO.Id);

            if (foundTasks == null)
            {
                return NotFound($"Task with ID {taskDTO.Id} not found.");
            }

            _taskService.UpdateTask(foundTasks);

            return Ok(foundTasks);
        }
    }
}
