using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teamer.DATA.Models
{
    public class Team
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int AdminId { get; set; }


        public string Name { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }

        [InverseProperty("Team")]
        public List<TeamUser> TeamUsers { get; set; } = new List<TeamUser>();
        #endregion

        public Team(User admin, string name, string? descrtiption, string? iconUrl)
        {
            AdminId = admin.Id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = descrtiption;
            IconUrl = iconUrl;
        }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// EF Core constructor
        /// </summary>
        public Team() { }
    }
}
