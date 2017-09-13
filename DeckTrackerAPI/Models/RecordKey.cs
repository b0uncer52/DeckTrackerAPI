
using System.ComponentModel.DataAnnotations;

namespace DeckTrackerAPI.Models
{
    public class RecordKey
    {
        [Key]
        public int RecordKeyId {get; set;}

        [Required]
        public int KeyId {get; set;}
        public KeyToVictory KeyToVictory {get; set;}

        [Required]
        public int RecordId {get; set;}
        public Record Record {get; set;}
    }
}