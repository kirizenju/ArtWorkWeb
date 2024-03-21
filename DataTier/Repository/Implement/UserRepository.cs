using DataTier.Models;
using DataTier.Repository.Interface;
using DataTier.View.User;

public class UserRepository : IUserRepository
{
    private readonly projectSWDContext _context;

    public UserRepository(projectSWDContext context)
    {
        _context = context;
    }

    public bool DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(e => e.IdUser == id);
        if (user == null) { return false; }
        _context.Users.Remove(user);
        _context.SaveChanges();
        return true;
    }

    public List<UserProfileViewModel> GetAllUser()
    {
        return _context.Users.Where(e => e.Role == "User" || e.Role == "Creator").Select(e => new UserProfileViewModel
        {
            Username = e.Username,
            Password = e.Password,
            Phone = e.Phone,
            Gender = e.Gender,
            Email = e.Email,
            Avatar =e.Avatar,
            Address = e.Address,
        }).ToList();
    }

    public User GetUserByEmail(string? email)
    {
        return _context.Users.Where(e => e.Email == email).FirstOrDefault();
    }

    public User? GetUserByID(int userid)
    {
        return _context.Users.Where(e => e.IdUser == userid).FirstOrDefault();
    }

    public User GetUserByUsername(string username)
    {
        return _context.Users.FirstOrDefault(e => e.Username == username);
    }

    public Task<User> Register(User user)
    {
        try
        {
            var newuser = new User
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Gender = user.Gender,
            };
            var result = _context.Users.Add(user);
            _context.SaveChanges();
            if (result == null) return Task.FromResult<User>(null);
            return Task.FromResult<User>(result.Entity);
        }
        catch
        {
            return Task.FromResult<User>(null);
        }
    }

    public bool UpdateProfile(ProfileUpdateRequest model)
    {
        try
        {
            var user = _context.Users.FirstOrDefault(u => u.IdUser == model.IdUser);

            if (user != null)
            {
                // Update the user properties with values from the model
                user.Gender = model.Gender;
                user.Email = model.Email;
                user.Avatar = model.Avatar;
                user.Phone = model.Phone;
                user.Address = model.Address;

                _context.SaveChanges();
                return true; // Profile update successful
            }

            return false; // User with the specified ID not found
        }
        catch (Exception ex)
        {
            // Log or handle the exception as needed
            return false; // Profile update failed
        }
    }
}