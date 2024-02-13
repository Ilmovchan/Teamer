using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teamer.DATA.Models
{
    public class User
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? IconUrl { get; set; }


        [InverseProperty("User")]
        public List<TeamUser> TeamUsers { get; set; } = new List<TeamUser>();

        [NotMapped]
        public Dictionary<Team, List<Task>> TeamTasks { get; set; }
        #endregion

        public User(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public User(string name, string? email, string? phone, string? iconUrl)
            : this(name)
        {
            if (!email.Contains('@')) throw new ArgumentException("Invalid email.", nameof(email));

            Email = email;
            Phone = phone;
            IconUrl = iconUrl;
        }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// EF Core constructor
        /// </summary>
        public User() { }
    }
}
