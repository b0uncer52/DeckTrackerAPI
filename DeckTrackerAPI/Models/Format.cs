
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeckTrackerAPI.Models
{
    public class Format
    {
        [Key]
        public int FormatId {get; set;}

        [Required]
        public string FormatName {get; set;}

        public ICollection<Deck> Decks {get; set;}
    }
}