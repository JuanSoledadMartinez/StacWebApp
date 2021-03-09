using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StacWebApp.Areas.Identity.Data;
using StacWebApp.Data;

[assembly: HostingStartup(typeof(StacWebApp.Areas.Identity.IdentityHostingStartup))]
namespace StacWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<StacDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("StacDBConnection")));

                services.AddDefaultIdentity<AppUser>(options => {
                    
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<StacDBContext>();
            });
        }
    }
}