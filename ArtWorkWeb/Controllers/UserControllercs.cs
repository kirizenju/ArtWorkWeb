using ArtWorkWeb.Service.Implement;
using ArtWorkWeb.Service.Interfaces;
using DataTier.View.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ArtWorkWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("profile/update")]
        public IActionResult ProfileUpdate(ProfileUpdateRequest model)
        {
            var reponse = _userService.UpdateProfile(model);
            return Ok(reponse);
        }
        [HttpGet("profile/get/{id}")]
        public IActionResult GetUser(int id)
        {
            var reponse = _userService.GetUser(id);
            if (reponse.Key.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                return NotFound(reponse.Key);
            }
            return Ok(reponse.Value);
        }
        [HttpDelete("profile/ban/{id}")]
        public IActionResult BanUser(int id)
        {
            var result = _userService.BanUser(id);
            if (result != false)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("profile/getall")]
        public IActionResult GetAllUser()
        {
            var response = _userService.GetAllUser();

            if (response.Key == null)
            {
                return NotFound("Response key is null.");
            }

            if (response.Key.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound(response.Key);
            }

            return Ok(response.Value);
        }

    
}
}
