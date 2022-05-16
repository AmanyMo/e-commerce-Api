using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userContext;
        public UserController(IUser userContext)
        {
                _userContext=userContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            IEnumerable<User>userList= _userContext.GetAll().Result;
            if (userList.Any())
            {
                return Ok(userList);
            }
            return NotFound();
        }
        [HttpGet("id")]
        public ActionResult<IEnumerable<User>> GetById(int id)
        {
            if (id<=0)
            {
                return BadRequest();
            }
            User user = _userContext.GetById(id).Result;
            if (user!=null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult PostNewUser(User user)
        {
           User returnUser= _userContext.Add(user).Result;
            if (returnUser!=null)
            {
                return CreatedAtAction(nameof(GetAll),returnUser);
            }
            else
            {
                return NotFound("no user added");
            }
        }
        [HttpPut]
        public ActionResult<User> PutUser(int id,User user)
        {
            if (id != user.UserID)
                return BadRequest();
            else
            {
                User returnUser= _userContext.Update(id,user).Result;
                if (returnUser != null)
                    return Ok(returnUser);
                else
                    return NotFound("can't modify user");
            }
        }

        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            bool ret = _userContext.Delete(id);
            if (ret)
            {
                return Ok("deleted");
            }
            else
            {
                return NotFound("user dose not exist");
            }

        }
    }
}
