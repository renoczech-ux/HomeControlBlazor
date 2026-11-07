using HomeControlBlazor.Models;
using HomeControlBlazor.Services;

namespace HomeControlBlazor.Services
{
    public class UserService : IUserService
    {
        // Implement authentication logic



        public async Task<User> Authenticate(string username, string password)
        {
            // Call API, validate credentials
            // Return user object if valid
            User user = new User();
            

            if (username == "a" && password == "b")
            {
                user.Username = username;
                user.Id = "1";
                var _user = user;
                return _user;
            }
            else
            {
                return null;
            }
           
           
        }

        public async Task SignOut()
        {
            // Clear stored user data
        }


    }
}
