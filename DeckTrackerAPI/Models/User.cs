using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeckTrackerAPI.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}

        [Required]
        public string UserName {get; set;}

        [Required]
        public string Password {get; set;}

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        public ICollection<TeamMember> TeamMembers {get; set;}
        public ICollection<Models.Version> Versions {get; set;}
        //public ICollection<Record> Records { get; set; }
        [InverseProperty("Winner")]
        [NotMapped]
        public ICollection<Record> Wins { get; set; }
        [InverseProperty("Loser")]
        [NotMapped]
        public ICollection<Record> Losses { get; set; }
    }
}