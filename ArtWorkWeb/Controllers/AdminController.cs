using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataTier.Models;
using System.Threading.Tasks;
using System.Linq;

namespace YourProjectNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly projectSWDContext _context;
        private readonly AdminControllerHelper _helper;

        public AdminController(projectSWDContext context, AdminControllerHelper helper)
        {
            _context = context;
            _helper = helper;
        }

        // PUT: api/Admin/BanUser/{id}
        [HttpPut("BanUser/{id}")]
        public async Task<IActionResult> BanUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.IsActive = false; // Ban the user by setting IsActive to false

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_helper.UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Admin/UnbanUser/{id}
        [HttpPut("UnbanUser/{id}")]
        public async Task<IActionResult> UnbanUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.IsActive = true; // Unban the user by setting IsActive to true

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_helper.UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}

public class AdminControllerHelper
{
    private readonly projectSWDContext _context;

    public AdminControllerHelper(projectSWDContext context)
    {
        _context = context;
    }

    public bool UserExists(int id)
    {
        return _context.Users.Any(e => e.IdUser == id);
    }
    [HttpGet("GetAllUsers")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }
}
