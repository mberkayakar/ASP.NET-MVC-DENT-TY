using Microsoft.AspNetCore.Identity;
using System;

namespace AKAR.WebUI.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreatedTime { get; set; }
    }
}
