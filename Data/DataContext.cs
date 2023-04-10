using StringCounterDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace StringCounterDemo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Strings> strings => Set<Strings>();
        public DbSet<StringsInfo> stringsInfos => Set<StringsInfo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }  
}
