using BSATask.Common.Interface;
using Microsoft.AspNetCore.Mvc;
using BSATask.Common.DTO;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        //api/projects
        [HttpGet]
        public ActionResult<IEnumerable<ProjectDTO>> GetAll()
        {
            return Ok(_projectService.GetProjects());
        }

        //api/projects/{id}
        [HttpGet("{id}")]
        public ActionResult<ProjectDTO> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var project = _projectService.GetProjectById(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        //api/projects
        [HttpPost]
        public IActionResult Add([FromBody] ProjectDTO projectDTO)
        {
            try
            {
                _projectService.AddProject(projectDTO);
                return CreatedAtRoute("GetById", new { id = projectDTO.Id }, projectDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //api/projects/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _projectService.GetProjects().FirstOrDefault(v => v.Id == id);

            if (project == null)
            {
                return NotFound();
            }
            if (id < 1)
            {
                return BadRequest();
            }

            _projectService.DeleteProject(project.Id);

            return NoContent();
        }

        //api/projects/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTeam([FromBody] ProjectDTO projectDTO)
        {
            var foundProject = _projectService.GetProjects().FirstOrDefault(t => t.Id == projectDTO.Id);

            if (foundProject == null)
            {
                return NotFound($"Project with ID {projectDTO.Id} not found.");
            }

            _projectService.UpdateProject(projectDTO);

            return Ok(projectDTO);
        }
    }
}
