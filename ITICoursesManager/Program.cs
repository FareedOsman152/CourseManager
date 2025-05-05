using ITICoursesManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ITICoursesManager;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddSession();
        builder.Services.AddIdentity<AppUser,IdentityRole>(options=>
        {
            options.Password.RequiredLength = 4;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = false;
        })
            .AddEntityFrameworkStores<ITIContext>();

        builder.Services.AddDbContext<ITIContext>(option =>
        {
            option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        
        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseSession();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        // MVC MiddleWare
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
