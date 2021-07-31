using CalorieTrackingApp.Business.Abstract;
using CalorieTrackingApp.Business.Concrete;
using CalorieTrackingApp.DataAccess.Abstract;
using CalorieTrackingApp.DataAccess.Concrete;
using CalorieTrackingApp.UI.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTrackingApp.UI
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
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            //{
            //    x.LoginPath = "/login/index";
            //});
            services.AddDbContext<IdentityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = false;
                

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;

                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/login/index";
                options.LogoutPath = "/login/logout";
                options.Cookie = new CookieBuilder
                {
                    Name = ".CalorieTracking.Security.Cookie"
                };
            });

            services.AddScoped<IFoodDal, EfFoodDal>();
            services.AddScoped<IMealDal, EfMealDal>();
            services.AddScoped<ICalculatorDal, EfCalculator>();

            services.AddScoped<IFoodService, FoodManager>();
            services.AddScoped<IMealService, MealManager>();
            services.AddScoped<ICalculatorService, CalculatorManager>();
            
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddControllersWithViews();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
          


            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=dashboard}/{action=Index}/{id?}");
            });
        }
    }
}
