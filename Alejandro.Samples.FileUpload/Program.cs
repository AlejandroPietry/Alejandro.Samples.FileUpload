using Alejandro.Samples.FileUpload.Services;
using Alejandro.Samples.FileUpload.Services.Interfaces;
using Microsoft.AspNetCore.Http.Features;

namespace Alejandro.Samples.FileUpload
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.Limits.MaxRequestBodySize = 524_288_000;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IBufferedFileUploadService, BufferedFileUploadService>();
            builder.Services.AddTransient<IStreamFileUploadService, StreamFileUploadService>();

            builder.Services.Configure<FormOptions>(options =>
            {
                //Set the limit to 500 MB
                options.MultipartBodyLengthLimit = 524288000;
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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}