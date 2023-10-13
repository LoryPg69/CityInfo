using CityInfo.Models.DbContent;
using CityInfo.NewFolder;
using CityInfo.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace CityInfo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


          

            builder.Services.AddControllers
            (opts =>
            {
                opts.ReturnHttpNotAcceptable = true;
            });

            builder.Services.AddDbContext<CityInfoContext>(cfg =>
            {
                var connectionString = "server=localhost; user=root; password=test123; database=testDB";
                ServerVersion sv = ServerVersion.AutoDetect(connectionString);
                var serverVision = new MySqlServerVersion(sv.Version);

                cfg.UseMySql(connectionString, serverVision).LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
            builder.Services.AddSingleton<ICityRepository, CityRepository>();

            #if DEBUG
            builder.Services.AddTransient<IMailService, LocalMailService>();
            #else
            #endif


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseAuthorization();


            //app.MapControllers();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("hello mother fuck");

            //});
            app.Run();
        }
    }
}