using Microsoft.EntityFrameworkCore;

namespace AddressBook.Repository.Data;

public class AddressBookDbContext : DbContext
{
    public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options)
        : base(options)
    {
    }

    public DbSet<AddressBook.Models.AddressBook> AddressBooks { get; set; }
}