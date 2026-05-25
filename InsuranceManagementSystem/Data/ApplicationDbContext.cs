using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<LifeInsurance> LifeInsurances { get; set; }
        public DbSet<MedicalInsurance> MedicalInsurances { get; set; }
        public DbSet<MotorInsurance> MotorInsurances { get; set; }
        public DbSet<HomeInsurance> HomeInsurances { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<NewsUpdate> NewsUpdates { get; set; }
        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Policy>()
                .HasOne(p => p.User)
                .WithMany(u => u.Policies)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Claim>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Claim>()
                .HasOne(c => c.Policy)
                .WithMany()
                .HasForeignKey(c => c.PolicyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-one relationships for insurance types
            modelBuilder.Entity<LifeInsurance>()
                .HasOne(l => l.Policy)
                .WithOne(p => p.LifeInsurance)
                .HasForeignKey<LifeInsurance>(l => l.PolicyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalInsurance>()
                .HasOne(m => m.Policy)
                .WithOne(p => p.MedicalInsurance)
                .HasForeignKey<MedicalInsurance>(m => m.PolicyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MotorInsurance>()
                .HasOne(m => m.Policy)
                .WithOne(p => p.MotorInsurance)
                .HasForeignKey<MotorInsurance>(m => m.PolicyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HomeInsurance>()
                .HasOne(h => h.Policy)
                .WithOne(p => p.HomeInsurance)
                .HasForeignKey<HomeInsurance>(h => h.PolicyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure indexes for performance
            modelBuilder.Entity<Policy>()
                .HasIndex(p => p.PolicyNumber)
                .IsUnique();

            modelBuilder.Entity<Policy>()
                .HasIndex(p => p.Status);

            modelBuilder.Entity<Payment>()
                .HasIndex(p => p.TransactionId)
                .IsUnique();

            modelBuilder.Entity<Loan>()
                .HasIndex(l => l.Status);

            modelBuilder.Entity<Claim>()
                .HasIndex(c => c.ClaimNumber)
                .IsUnique();

            modelBuilder.Entity<Claim>()
                .HasIndex(c => c.Status);
        }
    }
}
