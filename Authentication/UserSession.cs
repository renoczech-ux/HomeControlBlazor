using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HomeControlBlazor.Authentication
{
    public class UserSession
    {
        public string UserName { get; set; }    
        public string Role { get; set; }
    }
}
