using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Repository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AddressBookEntity> AddressBooks { get; set; }
        public DbSet<AddressBookModel> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressBookEntity>()
                .HasMany(a => a.Contacts)
                .WithOne(c => c.AddressBookEntity)
                .HasForeignKey(c => c.AddressBookEntityId);
        }
    }
}
