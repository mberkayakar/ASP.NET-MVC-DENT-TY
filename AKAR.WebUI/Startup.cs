using AKAR.WebUI.Context;
using AKAR.WebUI.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AKAR.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();
            services.AddControllersWithViews();
            
            // dbcontext db stringini verebilmek için bu şekil bir yöntem izlemek istedim 
            services.AddDbContext<MyDbContext>(opt => { opt.UseSqlServer(Configuration.GetConnectionString("Default")); });
            // mvc kısmı için

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MyDbContext>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , MyDbContext db )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                RequestPath = "/node_modules",
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules"))

            });

            app.UseRouting();

            app.UseAuthorization();

            db.Database.Migrate();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});

            // blazor page için yukarıdaki yapılandırmalar gerekmektedir.

            // MVC PROJESİ İÇİN ENDPOİNT YAPILANDIRMASI 


            app.UseEndpoints(x => {
                x.MapControllerRoute(
                    name:"default",
                    pattern : "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
