using BankLoanManagement.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BankLoanManagement.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<LoanType> LoanTypes { get; set; }

        public DbSet<LoanApplication> LoanApplications { get; set; }

        public DbSet<Loan> Loans { get; set; }

        public DbSet<LoanEMI> LoanEMIs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customer -> LoanApplication (1 : Many)
            modelBuilder.Entity<LoanApplication>()
                .HasOne(la => la.Customer)
                .WithMany(c => c.LoanApplications)
                .HasForeignKey(la => la.CustomerId);

            // LoanType -> LoanApplication (1 : Many)
            modelBuilder.Entity<LoanApplication>()
                .HasOne(la => la.LoanType)
                .WithMany(lt => lt.LoanApplications)
                .HasForeignKey(la => la.LoanTypeId);

            // LoanApplication -> Loan (1 : 1)
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.LoanApplication)
                .WithOne(la => la.Loan)
                .HasForeignKey<Loan>(l => l.ApplicationId);

            // Loan -> LoanEMI (1 : Many)
            modelBuilder.Entity<LoanEMI>()
                .HasOne(e => e.Loan)
                .WithMany(l => l.LoanEMIs)
                .HasForeignKey(e => e.LoanId);
        }
    }
}