using Microsoft.AspNetCore.Mvc;
using BussinessTier;
using ArtWorkWeb.Service.Interfaces;
using BussinessTier.Constants;
using BussinessTier.Payload.User;
using BussinessTier.Payload.ArtWork;
using BussinessTier.Payload;

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

        [HttpPost(ApiEndPointConstant.Authentication.Login)]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(UnauthorizedObjectResult))]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var loginResponse = await _userService.Login(loginRequest);
            if (loginResponse == null)
                throw new BadHttpRequestException(MessageConstant.LoginMessage.InvalidUsernameOrPassword);
            //if (loginResponse.Status == AccountStatus.Deactivate)
            //    throw new BadHttpRequestException(MessageConstant.LoginMessage.DeactivatedAccount);
            return Ok(loginResponse);
        }
        //[HttpGet(ApiEndPointConstant.User.UsersEndpoint)]
        //[ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAllUsers([FromQuery] UserFilter filter, [FromQuery] PagingModel pagingModel)
        //{
        //    var response = await _userService.GetAllUsers(filter, pagingModel);
        //    return Ok(response);
        //}
    }
}
