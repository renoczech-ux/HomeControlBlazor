using Microsoft.Identity.Client;

namespace HomeControlBlazor.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _users; // = new List<UserAccount>();

        public UserAccountService()
        {
            _users = new List<UserAccount>
            {
                new UserAccount { UserName = "bestama", Password = "Renko1983", Role = "Administrator" },
                //new UserAccount { UserName = "user", Password = "user", Role = "User" },
                new UserAccount { UserName = "vste", Password = "a2", Role = "VSTE" },
                new UserAccount { UserName = "vste_ing", Password = "k2", Role = "VSTE_ING" },
                new UserAccount { UserName = "vse", Password = "2025", Role = "VSE" },
                 new UserAccount { UserName = "tatka", Password = "Standa", Role = "tatka" },
                 new UserAccount { UserName = "Pavla", Password = "FilipekRadecek414", Role = "Pavla" }
            };
        }

        public UserAccount? GetByUserName(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);  
        }
    }
}
