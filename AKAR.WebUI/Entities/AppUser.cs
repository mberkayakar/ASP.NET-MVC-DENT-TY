using Microsoft.AspNetCore.Identity;

namespace AKAR.WebUI.Entities
{
    public class AppUser: IdentityUser<int>
    {
        public string ImagePath { get; set; }
        public string Gender { get; set; }

    }
}
