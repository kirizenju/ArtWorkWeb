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

    public User? GetUserByID(int userid)
    {
        return _context.Users.Where(e => e.IdUser == userid).FirstOrDefault();
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