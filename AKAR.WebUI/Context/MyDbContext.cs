using AKAR.WebUI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AKAR.WebUI.Context
{

    // identit
    public class MyDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {

        }
    }
}
