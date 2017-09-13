
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeckTrackerAPI.Models
{
    public class Team
    {
        [Key]
        public int TeamId {get; set;}

        [Required]
        public string TeamName {get; set;}

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        public ICollection<TeamMember> TeamMembers {get; set;}
    }
}