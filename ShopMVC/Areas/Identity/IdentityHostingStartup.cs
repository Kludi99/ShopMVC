using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopMVC.Areas.Identity.Data;
using ShopMVC.Data;

[assembly: HostingStartup(typeof(ShopMVC.Areas.Identity.IdentityHostingStartup))]
namespace ShopMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ShopMVCContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ShopMVCContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ShopMVCContext>();
            });
        }
    }
}