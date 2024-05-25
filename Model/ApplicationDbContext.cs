using Microsoft.EntityFrameworkCore;

namespace Manager_User_API.Model
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<User>? Users { get; set; }
        public DbSet<Form>? Forms { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Claim>? Claims { get; set; }
        public DbSet<UserRole>? UserRoles { get; set; }
       // public DbSet<UserClaim>? UserClaims { get; set; }
        public DbSet<Position>? Positions { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


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

            /*modelBuilder.Entity<UserClaim>()
                .HasKey(uc => new { uc.UserId, uc.ClaimId });
*/
            modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<RoleClaim>()
                .HasKey(rc => new { rc.RoleId, rc.ClaimId });

            modelBuilder.Entity<RoleClaim>()
                .HasOne(rc => rc.Role)
                .WithMany(r => r.RoleClaims)
                .HasForeignKey(rc => rc.RoleId);

            modelBuilder.Entity<RoleClaim>()
                .HasOne(rc => rc.Claim)
                .WithMany(c => c.RoleClaims)
                .HasForeignKey(rc => rc.ClaimId);

            modelBuilder.Entity<Form>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId);
        }
    }
}
