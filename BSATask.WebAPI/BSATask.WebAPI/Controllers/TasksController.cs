using BSATask.Common.Interface;
using BSATask.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using BSATask.Common.Sevices;

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
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var addedTaskDTO = _taskService.AddTask(taskDTO);
                if (addedTaskDTO is not null)
                {
                    return CreatedAtAction(nameof(Add), new { id = addedTaskDTO.Id }, addedTaskDTO);
                }
                else
                {
                    return BadRequest("Failed to add the task.");
                }
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
        public IActionResult UpdateTeam(int id, [FromBody] TaskDTO taskDTO)
        {
            var foundTasks = _taskService.GetTasks().FirstOrDefault(t => t.Id == id);

            if (foundTasks == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            _taskService.UpdateTask(taskDTO);

            return Ok(taskDTO);
        }
    }
}
