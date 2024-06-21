using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<LabTest> LabTests { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<TestResult> TestResults { get; set; }
    public DbSet<Billing> Billings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define relationships and other configurations
    }
}