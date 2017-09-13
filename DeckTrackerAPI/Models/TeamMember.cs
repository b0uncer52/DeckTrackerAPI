
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeckTrackerAPI.Models
{
    public class TeamMember 
    {
        [Key]
        public int TeamMemberId {get; set;}

        [Required]
        public int UserId {get; set;}
        public User User {get; set;}

        [Required]
        public int TeamId {get; set;}
        public Team Team {get; set;}

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateJoined { get; set; }
    }
}