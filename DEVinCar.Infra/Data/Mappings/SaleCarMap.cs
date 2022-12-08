using System;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCar.Infra.Data.Mappings
{
    public class SaleCarMap : IEntityTypeConfiguration<SaleCar>
    {
        public void Configure(EntityTypeBuilder<SaleCar> builder)
        {
            builder.ToTable("SaleCars");
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.Id)
                .HasColumnType("int");

            builder.Property(sc => sc.SaleId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(sc => sc.CarId)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(sc => sc.UnitPrice)
                .HasPrecision(18, 2);

            builder.Property(sc => sc.Amount)
                .HasColumnType("int");

            builder.HasOne<Car>(c => c.Car)
                .WithMany(c => c.Sales)
                .HasForeignKey(c => c.Id);

            builder.HasOne<Sale>(s => s.Sale)
                .WithMany(c => c.Cars)
                .HasForeignKey(s => s.Id);
        }
    }
}