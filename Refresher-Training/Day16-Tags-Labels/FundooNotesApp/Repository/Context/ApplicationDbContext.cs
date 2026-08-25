using Microsoft.EntityFrameworkCore;
using Repository.Entity;

namespace Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tag>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tag>()
                .HasIndex(t => new { t.UserId, t.Name })
                .IsUnique();

            // Many-to-many join table, with explicit FK delete behavior to avoid
            // SQL Server's "multiple cascade paths" error: deleting a Note cascades
            // and removes its NoteTags rows (Cascade), but deleting a Tag does NOT
            // cascade into NoteTags (NoAction) - the app must detach a tag from its
            // notes before deleting the tag itself.
            modelBuilder.Entity<Note>()
                .HasMany(n => n.Tags)
                .WithMany(t => t.Notes)
                .UsingEntity<Dictionary<string, object>>(
                    "NoteTags",
                    right => right.HasOne<Tag>().WithMany().HasForeignKey("TagsTagId").OnDelete(DeleteBehavior.NoAction),
                    left => left.HasOne<Note>().WithMany().HasForeignKey("NotesNoteId").OnDelete(DeleteBehavior.Cascade),
                    join => join.ToTable("NoteTags")
                );
        }
    }
}
