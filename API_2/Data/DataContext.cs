using API_2.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API_2.Data
{
        public class DataContext : IdentityDbContext<User, Role, int,
            IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
            IdentityRoleClaim<int>, IdentityUserToken<int>>
        {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DataContext(DbContextOptions options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DbSet<Company> Companies { get; set; }
            public DbSet<Service> Services { get; set; }
            public DbSet<CompanyProfile> CompanyProfiles { get; set; }
            public DbSet<Client> Clients { get; set; }
            public DbSet<ClientService> ClientServices { get; set; }
            public DbSet<SessionToken> SessionTokens { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<UserRole>(ur =>
                {
                    ur.HasKey(ur => new { ur.UserId, ur.RoleId });
                    ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                    ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
                });

                // one to many
                modelBuilder.Entity<Company>()
                    .HasMany(c => c.Services)
                    .WithOne(s => s.Company);

                // one to one
                modelBuilder.Entity<Company>()
                    .HasOne(c => c.CompanyProfile)
                    .WithOne(c => c.Company);

                // many to many
                modelBuilder.Entity<ClientService>().HasKey(cs => new { cs.ClientId, cs.ServiceId });

                modelBuilder.Entity<ClientService>()
                    .HasOne(c => c.Client)
                    .WithMany(c => c.ClientServices)
                    .HasForeignKey(c => c.ClientId);

                modelBuilder.Entity<ClientService>()
                    .HasOne(c => c.Service)
                    .WithMany(c => c.ClientServices)
                    .HasForeignKey(c => c.ServiceId);

            }
        }
}
