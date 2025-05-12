using Autofac.Extensions.DependencyInjection;
using Autofac;
using System.Reflection;
using Customerservice.Framework;
using Microsoft.EntityFrameworkCore;

namespace Customerservice.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            var assemblyName = Assembly.GetExecutingAssembly().FullName;
            var webHostEnvironment = builder.Environment.WebRootPath;

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterModule(new WebModule());
                containerBuilder.RegisterModule(new FrameworkModule(connectionString,
                        assemblyName, webHostEnvironment));
            });




            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString, m => m.MigrationsAssembly(assemblyName)));
            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();


            builder.Services.AddControllers();

            // Configure the HTTP request pipeline.
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSites", policy =>
            //    {
            //        policy.WithOrigins("https://localhost:44335") // Blazor client URL
            //              .AllowAnyHeader()
            //              .AllowAnyMethod();
            //    });
            //});

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            // app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            //app.UseCors("AllowSites"); // <- ADD THIS

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
