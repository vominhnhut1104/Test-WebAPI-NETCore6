using Microsoft.AspNetCore.Identity;

namespace Test_WebAPI_NETCore6.DataModel
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
