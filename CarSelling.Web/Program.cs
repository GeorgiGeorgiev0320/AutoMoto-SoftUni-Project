using System.Reflection;
using CarSelling.Data;
using CarSelling.Data.Models;
using CarSelling.Services.Data;
using CarSelling.Services.Data.Interfaces;
using CarSelling.Services.Mapping;
using CarSelling.Web.Infrastructure.Extensions;
using CarSelling.Web.Infrastructure.ModelBinders;
using CarSelling.Web.ViewModels.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CarSelling.Common.AppConstants;

namespace CarSelling.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<CarSellingDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.Password.RequireLowercase =
                        builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
                    options.Password.RequireUppercase = 
                        builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
                    options.Password.RequiredLength =
                        builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
                    options.Password.RequireNonAlphanumeric =
                        builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                    options.SignIn.RequireConfirmedAccount =
                        builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<CarSellingDbContext>();

            builder.Services.AddApplicationServices(typeof(ICarService));
            builder.Services.AddRecaptchaService();

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
                cfg.AccessDeniedPath = "/Home/Error/401";
            });

            builder.Services.AddControllersWithViews()
                .AddMvcOptions(options =>
                {
                    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
                });

            var app = builder.Build();

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);


            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.EnableOnlineUsersCheck();

            app.SeedAdministrator(DevelopmentAdminEmail);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "ProtectingUrlRoute",
                    pattern: "/{controller}/{action}/{id}/{information}",
                    defaults: new { Controller = "Category", Action = "Details" });
                   
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
            
            app.Run();
        }
    }
}