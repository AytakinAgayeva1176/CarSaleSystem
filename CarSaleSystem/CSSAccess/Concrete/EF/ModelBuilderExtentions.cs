using CSSEntity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSAccess.Concrete.EF
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Brand>().HasData(

                new Brand() { Id = 1, Name = "Audi" },
                  new Brand() { Id = 2, Name = "Mercedes" },
                    new Brand() { Id = 3, Name = "Porsche" }
            );

            builder.Entity<Model>().HasData(

                  new Model() { Id = 1, BrandId = 1, Name = "Q7" },
                    new Model() { Id = 2, BrandId = 1, Name = " A8" },
                      new Model() { Id = 3, BrandId = 2, Name = "S 500" },
                        new Model() { Id = 4, BrandId = 2, Name = "GLE 450" },
                          new Model() { Id = 5, BrandId = 3, Name = "Panamera" },
                            new Model() { Id = 6, BrandId = 3, Name = "Taycan" }
           );

            builder.Entity<Transmission>().HasData(

                  new Transmission() { Id = 1, Name = "Manual" },
                    new Transmission() { Id = 2, Name = "Automatic" }
            );

        }
    }
}
