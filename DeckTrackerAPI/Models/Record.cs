
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeckTrackerAPI.Models
{
    public class Record
    {
        [Key]
        public int RecordId {get; set;}

        [Required]
        public int WinnerUserId {get; set;}
        [ForeignKey("WinnerUserId")]
        [NotMapped]
        public User Winner {get; set;}

        [Required]
        public int LoserUserId { get; set; }
        [ForeignKey("LoserUserId")]
        [NotMapped]
        public User Loser { get; set; }

        [Required]
        public int WinningVersionId {get; set; }
        [ForeignKey("WinningVersionId")]
        [NotMapped]
        public Models.Version WinningVersion {get; set;}

        [Required]
        public int LoserVersionId { get; set; }
        [ForeignKey("LoserVersionId")]
        [NotMapped]
        public Version LosingVersion { get; set; }

        [Required]
        [Range(-7, 0)]
        public int WinnerMulligan {get; set;}

        [Required]
        [Range(-7, 0)]
        public int LoserMulligan {get; set;}

        [Required]
        public bool BoardedGame {get; set;}

        [Required]
        [Range(0, 10)]
        public int Closeness {get; set;}

        [Required]
        public string Notes {get; set;}

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
    }
}