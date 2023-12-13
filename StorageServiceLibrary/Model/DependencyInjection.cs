using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServiceLibrary.Model
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {

            services.AddDbContext<AppDB>(opt => opt

               .UseSqlServer("Server=.\\SQLEXPRESS;Database=AgroCostsDB;Trusted_Connection=True;TrustServerCertificate=True;"));
         //    .UseSqlServer("server=(LocalDb)\\MSSQLLocalDB; database = AgroCostsDB ;Integrated Security=True"));



            return services;
        }




    }
}
