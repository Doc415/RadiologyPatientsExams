using Microsoft.EntityFrameworkCore;
using RadiologyPatientsExams.Data;
using RadiologyPatientsExams.Repositories;
using RadiologyPatientsExams.Services;
namespace RadiologyPatientsExams
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<RadiologyDb>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("RadiologyDb") ?? throw new InvalidOperationException("Connection string 'RadiologyDb' not found.")));

            builder.Services.AddScoped<IRadiologyPatientRepository, PatientRepository>();
            builder.Services.AddScoped<PatientService>();

            builder.Services.AddScoped<IRadiologyExamRepository, ExamRepository>();
            builder.Services.AddScoped<ExamService>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
