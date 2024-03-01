using CDN.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CDN.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.Mail).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.PhoneNumber).HasMaxLength(15);
            modelBuilder.Entity<User>().Property(u => u.Skillsets).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Hobby);

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "JohnDoe", Mail = "johndoe@example.com", PhoneNumber = "1234567890", Skillsets = "C#, .NET", Hobby = "Gardening" },
                new User { Id = 2, Username = "JaneDoe", Mail = "janedoe@example.com", PhoneNumber = "0987654321", Skillsets = "JavaScript, React", Hobby = "Photography" }
            );
        }
    }
}
