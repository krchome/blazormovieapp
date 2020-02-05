using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorMovieApp.Areas.Identity;
using BlazorMovieApp.Data;
using BlazorMovieApp.Services;

namespace BlazorMovieApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddSingleton<WeatherForecastService>();
            //Add the Data Access Service
            services.AddTransient<IMovieDbService, MovieDbService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            CreateUserAndRoles(serviceProvider).Wait();
        }

        private async Task CreateUserAndRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 1
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //Here you could create a super user who will maintain the web app
            var poweruser = new IdentityUser
            {

                UserName = "test@hotmail.com",
                Email = "test@hotmail.com",
            };
            //Ensure you have these values in your appsettings.json file
            string userPWD = "Test@1234";
            var _user = await UserManager.FindByEmailAsync("test@hotmail.com");

            if (_user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(poweruser, "User");

                }
            }
            var poweruser1 = new IdentityUser
            {

                UserName = "test1@hotmail.com",
                Email = "test1@hotmail.com",
            };
            //Ensure you have these values in your appsettings.json file
            string userPWD1 = "Test1@1234";
            var _user1 = await UserManager.FindByEmailAsync("test1@hotmail.com");

            if (_user1 == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser1, userPWD1);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(poweruser1, "User");

                }
            }
            var poweruser2 = new IdentityUser
            {

                UserName = "test2@hotmail.com",
                Email = "test2@hotmail.com",
            };
            //Ensure you have these values in your appsettings.json file
            string userPWD2 = "Test2@1234";
            var _user2 = await UserManager.FindByEmailAsync("test2@hotmail.com");

            if (_user2 == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser2, userPWD2);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(poweruser2, "User");

                }
            }
            var poweruser3 = new IdentityUser
            {

                UserName = "admin3@hotmail.com",
                Email = "admin3@hotmail.com",
            };
            //Ensure you have these values in your appsettings.json file
            string userPWD3 = "Admin3@1234";
            var _user3 = await UserManager.FindByEmailAsync("admin3@hotmail.com");

            if (_user3 == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser3, userPWD3);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role
                    await UserManager.AddToRoleAsync(poweruser3, "Admin");

                }
            }
        }
    }
}
