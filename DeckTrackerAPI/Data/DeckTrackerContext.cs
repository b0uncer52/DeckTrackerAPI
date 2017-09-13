using DeckTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace DeckTrackerAPI
{
    public class DeckTrackerContext : DbContext
    {
        public DeckTrackerContext(DbContextOptions<DeckTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Deck> Deck { get; set; }
        public DbSet<Format> Format { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<KeyToVictory> KeysToVictory { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamMember> TeamMember { get; set; }
        public DbSet<RecordKey> RecordKey { get; set; }
        public DbSet<Version> Version { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);

            builder.Entity<User>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<Record>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<Version>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<TeamMember>()
                .Property(b => b.DateJoined)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<Team>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}