using BSATask.Common.Interface;
using BSATask.Common.DTO;
using Microsoft.AspNetCore.Mvc;
using BSATask.DAL.Entities;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll()
        {
            return Ok(_userService.GetUsers());
        }

        //api/users/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var user = _userService.GetUserById(id - 1);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //api/users
        [HttpPost]
        public IActionResult Add([FromBody] UserDTO userDTO)
        {
            try
            {
                _userService.AddUser(userDTO);

                return CreatedAtRoute("GetById", new { id = userDTO.Id }, userDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetUsers().FirstOrDefault(v => v.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            
            if (id < 1)
            {
                return BadRequest();
            }

            _userService.DeleteUser(id);

            return NoContent();
        }

        //api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateTeam([FromBody] UserDTO userDTO)
        {
            var foundUser = _userService.GetUsers().FirstOrDefault(t => t.Id == userDTO.Id);

            if (foundUser == null)
            {
                return NotFound($"User with ID {userDTO.Id} not found.");
            }

            _userService.UpdateUser(foundUser); 

            return Ok(foundUser);
        }
    }
}
