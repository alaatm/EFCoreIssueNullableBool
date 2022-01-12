using Microsoft.EntityFrameworkCore;

namespace EFCoreIssueNullableBool;

public class MyContext : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        //.UseSqlite("Data Source=tst.db;");
        .UseSqlServer(@"Server=.;Database=EFCoreIssueNullableBool;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Vehicle>()
            .HasOne(p => p.Registration)
            .WithOne()
            .HasForeignKey<VehicleRegistration>("vehicle_id")
            .IsRequired();
    }
}