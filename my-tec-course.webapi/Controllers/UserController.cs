using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace my_tec_course.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                // Attempt to sign out the user
                await _signInManager.SignOutAsync();
                return Ok(new { Message = "User logged out successfully" });
            }
            catch (Exception ex)
            {
                // If something goes wrong, handle the exception and return an appropriate response
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred during logout", Details = ex.Message });

            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "An error occurred during User Fetch", Details = ex.Message });
            }
        }

    }   
}
