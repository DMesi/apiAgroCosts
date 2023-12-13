using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServiceLibrary.Model
{
    public class AppDB : DbContext
    {
        public AppDB(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Seed> Seeds { get; set; }
        public DbSet<Plan> Plans { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Field>().HasData(

             new Field
             {
                 Id_Field = "2494/20",
                 Name = "Kuvajt",
                 Ha = 2,
                 J = 3.5,
                 Link = "",
                 Note = ""
             },
             new Field
             {
                 Id_Field = "7739",
                 Name = "Kanal",
                 Ha = 1.5,
                 J = 2.25,
                 Link = "https://a3.geosrbija.rs/share/0dfacc67fca1",
                 Note = ""
             }
            );


            builder.Entity<Seed>().HasData(
            new Seed
            {
               Id_Seed = 1,
                Name = "Korn",
                Note = ""

            },
            new Seed
            {
               Id_Seed = 2,
                Name = "Soybean",
                Note = ""

            },
             new Seed
             {
                 Id_Seed = 3,
                 Name = "Wheat",
                 Note = ""

             }
            );

            builder.Entity<Plan>().HasData(
            new Plan
            {   Id_plan =1,
                Year = DateTime.ParseExact("2024", "yyyy", null),
                FieldRefId = "7739",
                SeedRefId = 2,
                Ha = 1.5,
                J = 2.25,
                Note = ""
            }
      );


        }
    }
}
