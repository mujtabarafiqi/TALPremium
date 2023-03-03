using Microsoft.EntityFrameworkCore;
using TALPremium.Repository.Abstract;
using TALPremium.Repository.Concrete;
using TALPremium.Repository.Context;
namespace TALPremium
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Injection of database context
            builder.Services.AddDbContext<TALDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // DI for repositories for database access
            builder.Services.AddScoped<IOccupationRepository, OccupationRepository>();


            // Add services to the container.

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}