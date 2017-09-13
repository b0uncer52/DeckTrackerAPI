
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeckTrackerAPI.Models
{
    public class Version
    {
        [Key]
        public int VersionId {get; set;}

        [Required]
        public int DeckId {get; set;}
        public Deck Deck {get; set;}

        [Required]
        public int AuthorId {get; set;}
        public User Author {get; set;}

        [Required]
        public string DeckList {get; set;}

        [Required]
        public string VersionName {get; set;}
        
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        //public ICollection<Record> Records { get; set; }
        [InverseProperty("WinningVersion")]
        [NotMapped]
        public ICollection<Record> VersionWins { get; set; }
        [InverseProperty("LosingVersion")]
        [NotMapped]
        public ICollection<Record> VersionLosses { get; set; }
    }
}