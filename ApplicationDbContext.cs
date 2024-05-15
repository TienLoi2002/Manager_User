using Manager_User_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Manager_User_Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<User>? Users { get; set; }
        public DbSet<Form>? Forms { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Claim>? Claims { get; set; }
        public DbSet<UserRole>? UserRoles { get; set; }
        public DbSet<UserClaim>? UserClaims { get; set; }
        public DbSet<Position>? Positions { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=NGUYENTIENLOI\\NGUYENTIENLOI;Database=Manager_User;Trusted_Connection=True;TrustServerCertificate=True;");
        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
           .HasOne(u => u.Position) // Mỗi User có một Position
           .WithMany(p => p.Users)  // Mỗi Position có nhiều Users
           .HasForeignKey(u => u.PositionId); // Foreign key là PositionId

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserClaim>()
                .HasKey(uc => new { uc.UserId, uc.ClaimId });

            modelBuilder.Entity<Form>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId);
        }
    }
}
