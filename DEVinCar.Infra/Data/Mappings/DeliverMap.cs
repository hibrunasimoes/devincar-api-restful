using System;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCar.Infra.Data.Mappings
{
    public class DeliveryMap : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> builder)
        {
            builder.ToTable("Deliveries");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnType("int");

            builder.Property(d => d.AddressId)
                .HasColumnType("int");

            builder
                .Property(d => d.SaleId)
                .HasColumnType("int");

            builder
                .Property(d => d.DeliveryForecast);


            builder.HasOne<Address>(a => a.Address)
                .WithMany(d => d.Deliveries)
                .HasForeignKey(a => a.AddressId);

            builder.HasOne<Sale>(s => s.Sale)
                .WithMany(d => d.Deliveries)
                .HasForeignKey(s => s.SaleId);
        }
    }
}