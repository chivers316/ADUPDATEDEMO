using ADASSESSMENT.Models;
using Microsoft.EntityFrameworkCore;

namespace ADASSESSMENT.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Engineer> Engineers => Set<Engineer>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<TimeSlot> TimeSlots => Set<TimeSlot>();
        public DbSet<JobCategory> JobCategories => Set<JobCategory>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }  
}
