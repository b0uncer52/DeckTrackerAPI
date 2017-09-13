
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeckTrackerAPI.Models
{
    public class KeyToVictory
    {
        [Key]
        public int KeyId {get; set;}

        [Required]
        public string KeyName {get; set;}

        public ICollection<RecordKey> RecordKeys {get; set;}
    }
}