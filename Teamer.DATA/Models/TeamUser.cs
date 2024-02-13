using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teamer.DATA.Models
{
    public class TeamUser
    {
        [Key]
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        [Key]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public override string ToString()
        {
            return $"TeamId: {TeamId}, Team: {Team}, UserId:{UserId}, User:{User}";
        }
    }
}