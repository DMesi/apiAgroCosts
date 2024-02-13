using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<ReproMaterial> ReproMaterials { get; set; }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoleConfiguration()); // include from RoleConfiguration.cs

            builder.Entity<Field>().HasData(

             new Field
             {
                 Id_Field =1,
                 Id_User ="48275",
                 Field_number = "2494/20",
                 Name = "Kuvajt",
                 Ha = 2,
                 Ar =0,
                 M= 0,
                 Link = "",
                 Note = ""
             },
             new Field
             {
                 Id_Field = 2,
                 Id_User = "48275",
                 Field_number = "7739",
                 Name = "Kanal",
                 Ha = 1.5,
                
                 Link = "https://a3.geosrbija.rs/share/0dfacc67fca1",
                 Note = ""
             }
            );

            builder.Entity<Plan>().HasData(
            new Plan
            {   Id_plan =1,
                Id_User = "48275",
                Year = DateTime.ParseExact("2024", "yyyy", null),
                FieldRefId = 1,
                ReproMaterialRefId = 1,
                Ha = 1,
                Note = ""
            },
             new Plan
             {
                 Id_plan = 2,
                 Id_User = "48275",
                 Year = DateTime.ParseExact("2024", "yyyy", null),
                 FieldRefId = 1,
                 ReproMaterialRefId = 2,
                 Ha = 1,
               
                 Note = ""
             }, new Plan
             {
                 Id_plan = 3,
                 Id_User = "48275",
                 Year = DateTime.ParseExact("2024", "yyyy", null),
                 FieldRefId = 2,
                 ReproMaterialRefId = 1,
                 Ha = 1.5,
                
                 Note = ""
             }
      );

            builder.Entity<Category>().HasData(
            new Category
            {
                Id_Category = 1,
                TypeCategory = 1,
                TypeCategoryName = "CategorySeed",
                SubTypeCegory = 1,
                SubTypeCegoryName = "Corn"
            },
            new Category
            {
                Id_Category = 2,
                TypeCategory = 4,
                TypeCategoryName = "Fertilizer",
                SubTypeCegory = 1,
                SubTypeCegoryName = "UREA"

            } );

            builder.Entity<ReproMaterial>().HasData(
            new ReproMaterial
            {
                Id_Repro = 1,
                Id_User = "48275",
                Year = DateTime.ParseExact("2024", "yyyy", null),
                CategoryRefId = 1,
                Sort = "DKC5075",
                Price = 29990,
                UoM ="kg",
                Quantity =3,
                
                Note = ""

            },
             new ReproMaterial
             {
                 Id_Repro = 2,
                 Id_User = "48275",
                 Year = DateTime.ParseExact("2024", "yyyy", null),
                 CategoryRefId = 1,
                 Sort = "DKC5075",
                 Price = 29990,
                 UoM = "kg",
                 Quantity = 3,
                
                 Note = ""

             },
              new ReproMaterial
              {
                  Id_Repro = 1,
                  Id_User = "48275",
                  Year = DateTime.ParseExact("2024", "yyyy", null),
                  CategoryRefId = 4,
                  Sort = "UREA",
                  Price = 49990,
                  UoM = "T",
                  Quantity = 3,
                  
                  Note = ""

              }
            );

           


        }
    }
}
