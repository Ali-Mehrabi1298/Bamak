

using Bamak.Data.Repository;
using Bamak.Models;
using BookAudiomak.Data;

using BookAudiomak.Data.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Bamak
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
            services.AddControllersWithViews();
            services.AddRazorPages();


            services.AddAuthentication().AddGoogle(option =>
            {
                option.ClientId = "777872640192-l04udignstp0uc6i2un1oiclaoo4n76n.apps.googleusercontent.com";
                option.ClientSecret = "XOSNlWsSOS31g9bEliU9QEjZ";



            });

           
            #region Db Contex

              services.AddDbContext<Bookmakcontex>(options =>
            { options.UseSqlServer("Data Source=.;Initial Catalog=Bookmak;   Integrated Security = true "); });

            #endregion

            #region Ioc

            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        
            services.AddScoped<IEmailSender,EmailSender>();
            #endregion


            #region
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                    AddCookie(option =>
                    {

                        option.LoginPath = "/AccountUsers/Login";
                        option.LogoutPath = "/AccountUsers/Logout";
                        option.ExpireTimeSpan = TimeSpan.FromDays(10);



                    });

            #endregion

            #region SEndEmail

       //     services.AddDbContext<Bookmakcontex>(options =>
       //options.UseSqlServer(
       //    Configuration.GetConnectionString("DefaultConnection")));
       //        services.AddIdentityCore<IdentityUser>(
       //                   options => options.SignIn.RequireConfirmedAccount = true)
       //         .AddEntityFrameworkStores<Bookmakcontex>();

            // requires
            // using Microsoft.AspNetCore.Identity.UI.Services;
            // using WebPWrecover.Services;
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            services.AddRazorPages();

            #endregion

            #region Identityservise

            //services.AddDbContextPool<Bookmakcontex>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            //});
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 0;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            })
               .AddEntityFrameworkStores<Bookmakcontex>()
               .AddDefaultTokenProviders();

          



            #endregion
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            //app.Use(async (context, next) =>
            //{
            //    Do work that doesn't write to the Response.
            //    if (context.Request.Path.StartsWithSegments("/Admin"))
            //    {
            //        if (!context.User.Identity.IsAuthenticated)
            //        {
            //            context.Response.Redirect("/Account/Login");
            //        }
            //        else if (!bool.Parse(context.User.FindFirstValue("IsAdminn")))
            //        {
            //            context.Response.Redirect("/Account/Login");
            //        }
            //    }
            //    await next.Invoke();
            //    Do logging or other work that doesn't write to the Response.
            //});





            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapRazorPages();
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });

        }
    }
}

