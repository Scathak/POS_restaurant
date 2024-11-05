using Microsoft.EntityFrameworkCore;

namespace POS_restaurant
{
    class LabourContext : DbContext
    {
        public DbSet<LabourRecord> LabourRecords { get; set; }

        private readonly string _databasePath;

        public LabourContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LabourRecord>().HasKey(l => l.Number);
            modelBuilder.Entity<LabourRecord>().Property(l => l.FirstName).IsRequired();
            modelBuilder.Entity<LabourRecord>().Property(l => l.LastName).IsRequired();
            modelBuilder.Entity<LabourRecord>().Property(l => l.PhoneNumber).IsRequired();
            modelBuilder.Entity<LabourRecord>().Property(l => l.Email).IsRequired();
            modelBuilder.Entity<LabourRecord>().Property(l => l.ShiftDates).IsRequired();
        }
    }
}
