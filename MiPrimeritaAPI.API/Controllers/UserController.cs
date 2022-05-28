using Microsoft.AspNetCore.Mvc;
using MiPrimeritaAPI.BL.Contracts;
using MiPrimeritaAPI.BL.Implementations;
using MiPrimeritaAPI.CORE.DTO;

namespace MiPrimeritaAPI.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
    public IUserBL userBL { get; set; }
    public ILoginBL loginBL { get; set; }

    public UserController(IUserBL userBL, ILoginBL loginBl)
    {
        this.userBL = userBL;
        this.loginBL = loginBL;
    }

    /*
     * Register endpoint. Interacts with the BL and sends the User DTO to register.
     * Returns true if registered successfully, false if not registered successfully.
     */
    [Route("Reg")]
    [HttpPost]
    public ActionResult Register(UserDTO u)
    {
        if (userBL.Register(u))
            return Ok();
        return BadRequest();
    }

        /*
         * Logs an user in. Interacts with the BL and sends the Login DTO to log in.
         * Returns true if logged in; false if not logged in.
         */

       [Route("Login")]
       [HttpPost]
    public ActionResult Login(LoginDTO lo)
    {
        if (loginBL.Login(lo))
            return Ok();
        return BadRequest();
    }

        [HttpGet("All")]
        public ActionResult<List<UserDTO>> GetUsers()
    {
        return Ok(userBL.GetUsers());
    }

    [HttpGet]
    public ActionResult<UserDTO?> GetUsers(string Username)
    {
        var user = userBL.GetUser(Username);
        if (user != null)
            return Ok(user);
        else
            return NotFound();
    }

    [HttpPut]
    public ActionResult<UserDTO?> Update(UserDTO user)
    {
        userBL.Update(user);
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(string Username)
    {
        userBL.Delete(Username);
        return Ok();
    }
}
}
