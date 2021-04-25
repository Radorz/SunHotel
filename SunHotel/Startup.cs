using Automap.Automapper;
using DataBase.Models;
using EmailHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository.Repository;
using SunHotel.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SunHotel
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

            services.AddDbContext<ba4cpg3zvekknrm1lhokContext>(options => options.UseMySql(Configuration.GetConnectionString("Default")));
            services.AddAutoMapper(typeof(AutomapperConfinew).GetTypeInfo().Assembly);
            services.AddSession(so =>

            {

                so.IdleTimeout = TimeSpan.FromHours(5);
            }
            );
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {

                options.Password = new PasswordOptions
                {

                    RequireDigit = true,
                    RequireLowercase = false,
                    RequireNonAlphanumeric = false,
                    RequireUppercase = false,
                    RequiredLength = 6
                };

            }).AddEntityFrameworkStores<ba4cpg3zvekknrm1lhokContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
             

                // Lockout settings.
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 3;


                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(40);

                options.LoginPath = "/Home/Login";
                options.AccessDeniedPath = "/Home/Login"    ;
                options.SlidingExpiration = true;
            });

            services.AddScoped<TiposHabitacionRepository>();
            services.AddScoped<HabitacionRepository>();
            services.AddScoped<EdificiosRepository>();
            services.AddScoped<imghabitacionRepository>();
            services.AddScoped<ReservaRepository>();
            services.AddScoped<PagoRepository>();
            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EMconfi>();
            services.AddSingleton(emailConfig);
            services.AddScoped<Iemailsender, Gmailsender>();
            services.AddScoped<ITemplateHelper, TemplateHelper>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {

            CreateRoles(serviceProvider).Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            //Here you could create a super user who will maintain the web app
            var poweruser = new IdentityUser
            {

                UserName = Configuration["AppSettings:UserName"],
                Email = Configuration["AppSettings:UserEmail"],
            };
            string userPWD = Configuration["AppSettings:UserPassword"];
            var _user = await UserManager.FindByEmailAsync(Configuration["AppSettings:UserEmail"]);

            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(poweruser, "Admin");

                }
            }
        }
    }
}
