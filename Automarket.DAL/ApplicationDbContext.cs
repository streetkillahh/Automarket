using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Automarket.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasData(new User
                {
                    Id = 1,
                    Name = "streetkillah",
                    Password = HashPasswordHelper.HashPassowrd("123123"),
                    Role = Role.Admin
                });

                builder.ToTable("Users").HasKey(x => x.Id); //Primary Key

                builder.Property(x => x.Id)
                    .ValueGeneratedOnAdd(); //Автоинкремент

                builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            });
        }
    }
}