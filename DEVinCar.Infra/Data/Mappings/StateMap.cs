using System;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEVinCar.Infra.Data.Mappings
{
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States");
            builder.HasKey(s => s.Id);

            builder
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(s => s.Initials)
                .HasMaxLength(2)
                .IsRequired();

            builder
                .HasData(new[] {
                    new State (1, "Acre", "AC"),
                    new State (2, "Alagoas", "AL"),
                    new State (3, "Amapá", "AP"),
                    new State (4, "Amazonas", "AM"),
                    new State (5, "Bahia", "BA"),
                    new State (6, "Ceará", "CE"),
                    new State (7, "Distrito Federal", "DF"),
                    new State (8, "Espírito Santo", "ES"),
                    new State (9, "Goiás", "GO"),
                    new State (10, "Maranhão", "MA"),
                    new State (11, "Mato Grosso", "MT"),
                    new State (12, "Mato Grosso do Sul", "MS"),
                    new State (13, "Minas Gerais", "MG"),
                    new State (14, "Pará", "PA"),
                    new State (15, "Paraíba", "PB"),
                    new State (16, "Paraná", "PR"),
                    new State (17, "Pernambuco", "PE"),
                    new State (18, "Piauí", "PI"),
                    new State (19, "Rio de Janeiro", "RJ"),
                    new State (20, "Rio Grande do Norte", "RN"),
                    new State (21, "Rio Grande do Sul", "RS"),
                    new State (22, "Rondônia", "RO"),
                    new State (23, "Roraima", "RR"),
                    new State (24, "Santa Catarina", "SC"),
                    new State (25, "São Paulo", "SP"),
                    new State (26, "Sergipe", "SE"),
                    new State (27, "Tocantins", "TO")

                });
        }
    }
}