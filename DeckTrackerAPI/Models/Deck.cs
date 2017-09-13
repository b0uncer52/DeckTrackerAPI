
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeckTrackerAPI.Models
{
    public class Deck
    {
        [Key]
        public int DeckId {get; set;}

        [Required]
        public string DeckName {get; set;}

        [Required]
        public int FormatId {get; set;}
        public Format Format {get; set;}

        public ICollection<Models.Version> Versions {get; set;}
    }
}