using Innosuisse.Startupticker.WebApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;

namespace Innosuisse.Startupticker.WebApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Configuration
            //    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration
                    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
            }

            builder.Services.AddLogging();
            builder.Services.AddSerilog();
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.UseInlineDefinitionsForEnums();
            });
            builder.Services.AddProblemDetails();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder
                    .SetIsOriginAllowed((x) =>
                    {
                        return true;
                    })
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    );
            });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDbContextPool<ApplicationDbContext>((options) =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                Log.Logger = new LoggerConfiguration()
                   .WriteTo.Console()
                   .CreateLogger();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                Log.Logger =  new LoggerConfiguration()
                    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Hour)
                    .CreateLogger();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
