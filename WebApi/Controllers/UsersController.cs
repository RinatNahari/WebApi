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
            if (res)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("{id:int}", Name = "Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            var res = _userManager.Delete(id);
            if (res)
                return Ok();
            return NoContent();
        }

        [HttpPut("{password:string}", Name = "ValidateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ValidateUser([FromBody] UserDTO userDTO, string password)
        {
            var res = _userManager.Validate(userDTO, password);
            return Ok(res);
        }
    }
}
