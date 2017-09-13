using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeckTrackerAPI.Models;

namespace DeckTrackerAPI.Models
{
    public class DeckTrackerAPIContext : DbContext
    {
        public DeckTrackerAPIContext (DbContextOptions<DeckTrackerAPIContext> options)
            : base(options)
        {
        }

        public DbSet<DeckTrackerAPI.Models.Format> Format { get; set; }

        public DbSet<DeckTrackerAPI.Models.Deck> Deck { get; set; }

        public DbSet<DeckTrackerAPI.Models.Version> Version { get; set; }

        public DbSet<DeckTrackerAPI.Models.Team> Team { get; set; }

        public DbSet<DeckTrackerAPI.Models.TeamMember> TeamMember { get; set; }

        public DbSet<DeckTrackerAPI.Models.User> User { get; set; }

        public DbSet<DeckTrackerAPI.Models.KeyToVictory> KeyToVictory { get; set; }

        public DbSet<DeckTrackerAPI.Models.RecordKey> RecordKey { get; set; }

        public DbSet<DeckTrackerAPI.Models.Record> Record { get; set; }
    }
}
