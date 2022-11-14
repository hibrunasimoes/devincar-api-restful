using System.Runtime.Serialization;
using DEVinCar.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DEVinCar.Infra.Data;

public class DevInCarDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DevInCarDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    //public DbSet<XYZ> XYZs { get; set; }

    public DbSet<City> Cities { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleCar> SaleCars { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Address> Addresses { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(
            _configuration.GetConnectionString("DEV_IN_CAR")
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Exemplo
        // modelBuilder.Entity<XYZ>(entidade =>
        // {
        //     entidade.ToTable("[XYZ]s");

        //     entidade.HasKey(a => a.Id);

        //     entidade
        //         .Property(a => a.[prop])
        //         .HasMaxLength(120)
        //         .IsRequired();

        //     entidade
        //         .HasData(new[]{
        //             ...
        //         });
        // });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("Cities");
            entity.HasKey(a => a.Id);
            entity
                .Property(a => a.Name)
                .HasMaxLength(255)
                .IsRequired();
            entity
                .Property(a => a.StateId)
                .HasColumnType("int")
                .IsRequired();
            entity
                .HasOne<State>(city => city.State)
                .WithMany(s => s.Cities)
                .HasForeignKey(city => city.StateId)
                .IsRequired();

        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(u => u.Id);
            entity
                .Property(u => u.Email)
                .HasMaxLength(150)
                .IsRequired();

            entity
                .Property(u => u.Password)
                .HasMaxLength(50)
                .IsRequired();

            entity
                .Property(u => u.Name)
                .HasMaxLength(255)
                .IsRequired();

            entity
                .Property(u => u.BirthDate);
            entity
                .HasData(new[] {
                    new User (1, "jose@email.com", "123456opp78", "Jose", new DateTime(2000, 12, 10)),
                    new User (2, "andrea@email.com", "987dasd654321", "Andrea", new DateTime(1999, 05, 11)),
                    new User (3, "adao@email.com", "2589asd", "Adao", new DateTime(2005, 09, 02)),
                    new User (4, "monique@email.com", "asd45uio", "Monique", new DateTime(2001, 06, 07)),
                });
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.ToTable("Cars");
            entity.HasKey(c => c.Id);

            entity
                .Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();

            entity
                .Property(c => c.SuggestedPrice)
                .HasPrecision(18,2);
            entity
                .HasData(new[] {
                    new Car (1, "Camaro Chevrolet", 60000M),
                    new Car (2, "Maverick Ford", 20000M),
                    new Car (3, "Astra Chevrolet", 30000M),
                    new Car (4, "Hilux Toyota", 20000M),
                    new Car (5, "Bravo Fiat", 20000M),
                    new Car (6, "BR800 Gurgel", 10000M),
                    new Car (7, "147 Fiat", 50000M),
                    new Car (8, "Del Rey Ford", 10000M),
                    new Car (9, "Mustang Ford", 70000M),
                    new Car (10, "Belina Ford", 20000M)
                });
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("Sales");
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Id)
                .HasColumnType("int");

            entity.Property(s => s.SaleDate);
                

            entity.HasOne(u => u.UserBuyer)
                .WithMany()
                .HasForeignKey(u => u.BuyerId);

            entity.HasOne(u => u.UserSeller)
                .WithMany()
                .HasForeignKey(u => u.SellerId);       
        });

        modelBuilder.Entity<SaleCar>(entity =>
        {
            entity.ToTable("SaleCars");
            entity.HasKey(sc => sc.Id);
            entity.Property(sc => sc.Id)
                .HasColumnType("int");

            entity.Property(sc => sc.SaleId)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(sc => sc.CarId)
                .HasColumnType("int")
                .IsRequired();

            entity.Property(sc => sc.UnitPrice)
                .HasPrecision(18, 2);

            entity.Property(sc => sc.Amount)
                .HasColumnType("int");

            entity.HasOne<Car>(c => c.Car)
                .WithMany(c => c.Sales)
                .HasForeignKey(c => c.Id);                

            entity.HasOne<Sale>(s => s.Sale)
                .WithMany(c => c.Cars)
                .HasForeignKey(s => s.Id);                

        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.ToTable("Deliveries");

            entity.HasKey(d => d.Id);

            entity.Property(d => d.Id)
                .HasColumnType("int");

            entity.Property(d => d.AddressId)
                .HasColumnType("int");

            entity
                .Property(d => d.SaleId)
                .HasColumnType("int");

            entity
                .Property(d => d.DeliveryForecast);
                

            entity.HasOne<Address>(a=> a.Address)
                .WithMany(d => d.Deliveries)
                .HasForeignKey(a => a.AddressId);
            
            entity.HasOne<Sale>(s=> s.Sale)
                .WithMany(d => d.Deliveries)
                .HasForeignKey(s => s.SaleId);

        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Addresses");

            entity.HasKey(d => d.Id);

            entity.Property(d => d.CityId).HasColumnType("int").IsRequired();

            entity.Property(d => d.Street).HasMaxLength(150).IsRequired();

            entity.Property(d => d.Cep).HasMaxLength(8).IsRequired();

            entity.Property(d => d.Number).HasColumnType("int").IsRequired();

            entity.Property(d => d.Complement).HasMaxLength(255);

            entity.HasOne<City>(address => address.City)
            .WithMany(d => d.Addresses)
            .HasForeignKey(address => address.CityId)
            .IsRequired();
        }

      );

        modelBuilder.Entity<State>(entity =>
        {
            entity.ToTable("States");
            entity.HasKey(s => s.Id);

            entity
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();

            entity
                .Property(s => s.Initials)
                .HasMaxLength(2)
                .IsRequired();

            entity
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
        });
    }
}

