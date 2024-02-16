using Microsoft.AspNetCore.Mvc;

namespace ArtWorkWeb.Controllers
{
    [ApiController]
    public class AuthenticationController : BaseController<AuthenticationController>
    {
        private readonly IUserService _userService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IUserService userService) : base(logger)
        {
            _userService = userService;
        }

        [HttpPost(ApiEndPointConstant.User.UserLoginEndPoint)]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginUser(LoginFirebaseRequest request)
        {
            var response = await _userService.LoginUser(request);
            return Ok(response);
        }
    }
}
