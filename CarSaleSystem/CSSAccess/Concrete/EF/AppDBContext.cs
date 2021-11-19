using CSSEntity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSAccess.Concrete.EF
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");

            });

            builder.Entity<Model>(entity =>
            {
                entity.ToTable("Models");
                entity.HasOne(e => e.Brand)
                   .WithMany(e => e.Models)
                   .HasForeignKey(e => e.BrandId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<Transmission>(entity =>
            {
                entity.ToTable("Transmissions");

            });

            builder.Entity<Car>(entity =>
            {
                entity.ToTable("Cars");
                entity.HasOne(e => e.Brand)
                   .WithMany(e => e.Cars)
                   .HasForeignKey(e => e.BrandId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Model)
                  .WithMany(e => e.Cars)
                  .HasForeignKey(e => e.ModelId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Transmission)
                  .WithMany(e => e.Cars)
                  .HasForeignKey(e => e.TransmissionId)
                  .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Seed();

        }

    }
}
