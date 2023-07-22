using BSATask.Common.Interface;
using BSATask.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService; 
        }

        //api/teams
        [HttpGet]
        public ActionResult<IEnumerable<TeamDTO>> GetAll()
        {
            return Ok(_teamService.GetTeams());
        }

        //api/teams/{id}
        [HttpGet("{id}")]
        public ActionResult<TeamDTO> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var teams = _teamService.GetTeamById(id);

            if (teams == null)
            {
                return NotFound();
            }

            return Ok(teams);
        }

        //api/teams
        [HttpPost]
        public IActionResult Add([FromBody] TeamDTO teamDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var addedTeamDTO = _teamService.AddTeam(teamDTO);
                if (addedTeamDTO is not null)
                {
                    return CreatedAtAction(nameof(Add), new { id = addedTeamDTO.Id }, addedTeamDTO);
                }
                else
                {
                    return BadRequest("Failed to add the team.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //api/teams/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var team = _teamService.GetTeams().FirstOrDefault(v => v.Id == id);

            if (team == null)
            {
                return NotFound();
            }
            if (id < 1)
            {
                return BadRequest();
            }

            _teamService.DeleteTeam(id);

            return NoContent();
        }

        //api/teams/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id, [FromBody] TeamDTO teamDTO)
        { 
            var foundTeam = _teamService.GetTeams().FirstOrDefault(v => v.Id == id);

            if (foundTeam == null)
            {
                return NotFound($"Team with ID {id} not found.");
            }
            _teamService.UpdateTeam(teamDTO);

            return Ok(teamDTO);
        }
    }
}
