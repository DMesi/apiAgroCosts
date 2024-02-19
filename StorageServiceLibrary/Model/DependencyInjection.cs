using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StorageServiceLibrary.IRepository;
using StorageServiceLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageServiceLibrary.DTO;
using Microsoft.Extensions.Configuration;
using StorageServiceLibrary.Services;
using Microsoft.AspNetCore.Identity;

namespace StorageServiceLibrary.Model
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {

            services.AddTransient<IUnitOfWork, UnitOfWork>();
           
            // mmust be Scoped
            services.AddScoped<IAuthManager, AuthManager>();

            services.AddAutoMapper(typeof(MapperInitilizer));

            services.AddDbContext<AppDB>(opt => opt

               .UseSqlServer("Server=.\\SQLEXPRESS;Database=AgroCostsDB;Trusted_Connection=True;TrustServerCertificate=True;"));
            //    .UseSqlServer("server=(LocalDb)\\MSSQLLocalDB; database = AgroCostsDB ;Integrated Security=True"));



            services.AddAuthentication();

            //  ServiceExtensions.cs
            // services.ConfigureIdentity();

            //services.AddSwaggerGen(options => {
            //    options.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Title = "WEB APIxxx",
            //        Version = "v1"
            //    });
            //});

            ////Enable CORS
            //services.AddCors(c => {
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //});


            return services;
        }




    }
}
