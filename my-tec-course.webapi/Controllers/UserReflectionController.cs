using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_tec_course.webapi.Interfaces.Services;

namespace my_tec_course.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReflectionController : ControllerBase
    {
        private readonly IUserReflectionService _userReflectionService;

        public UserReflectionController(IUserReflectionService userReflectionService)
        {
            _userReflectionService = userReflectionService;
        }
    }
}
