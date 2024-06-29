using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserManager _userManager;
        public UsersController(UserManager userManager)
            => _userManager = userManager;

        [HttpGet]
        public IEnumerable<UserDTO> Get() => _userManager.GetUsers();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDTO> Post([FromBody] UserDTO userDTO)
        {
            var res = _userManager.Add(userDTO);
            if (res == null)
                return BadRequest(res);
            return Ok(res);
        }

        [HttpDelete("{id:int}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteUser(int id)
        {
            var res = _userManager.Delete(id);
            if (res < 0)
                return NotFound();
            return NoContent();
        }

    }
}
