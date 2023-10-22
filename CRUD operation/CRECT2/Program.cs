using CRECT2.Interface;
using CRECT2.Models;
using CRECT2.Reprosatorys;
using CRECT2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRECT2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Datacontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
            });
            builder.Services.AddScoped<Datacontext, Datacontext>();
            builder.Services.AddScoped<G_Interface<Employee>, EmployeeRepo>();
            builder.Services.AddScoped<G_Interface<Department>, DepartmentRepo>();
            builder.Services.AddScoped<G_Interface<Course>, CourseRepo>();
            builder.Services.AddScoped<VM_Interface_<Emp_For_Dept>, DepartmentRepo>();
            builder.Services.AddScoped<VMCours_Interface<Course_For_Emp>, CourseRepo>();
            builder.Services.AddScoped<Interface_Segragation<Course>, CourseRepo>();
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Datacontext>();
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

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default2",
                pattern: "{controller=Employee}/{action=ShowAll}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}