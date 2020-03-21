using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlexTrebot.Data
{
    public partial class triviaDbContext : DbContext
    {
        public triviaDbContext()
        {
        }

        public triviaDbContext(DbContextOptions<triviaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DiscordUsers> DiscordUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=(LocalDB)\\MSSQLLocalDB;Database=triviaDb;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscordUsers>(entity =>
            {
                entity.HasKey(e => e.DiscordUserId);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
