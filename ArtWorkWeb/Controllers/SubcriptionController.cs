using ArtWorkWeb.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtWorkWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcriptionController : ControllerBase
    {
        private readonly ISubcriptionService _subcriptionService;
        public SubcriptionController(ISubcriptionService subcriptionService)
        {
            _subcriptionService = subcriptionService;
        }
        [HttpGet("subciption/getall")]
        public IActionResult GetAllSub() 
        {
            var response = _subcriptionService.GetAllSub();
            return Ok(response.Value);
        }
    }
}
