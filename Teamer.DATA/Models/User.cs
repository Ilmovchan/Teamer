    using System;
    using System.ComponentModel.DataAnnotations;
    using Teamer.DATA.Models.Enums;

    namespace Teamer.DATA.Models
    {
        public class User
        {
            #region Properties
            [Key]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
            public string? Email { get; set; }
            public string? Phone { get; set; }
            public string? IconUrl { get; set; }
            public Role? Role { get; set; }
            #endregion

            public User(string name, string password)
            {
                Name = name ?? throw new ArgumentNullException(nameof(name)); 
                Password = password ?? throw new ArgumentNullException(nameof(password));
            }

            public User(string name, string password, string? email, string? phone, string? iconUrl, Role? role = Enums.Role.None)
                :this (name, password)
            {
                Email = email;
                Phone = phone;
                IconUrl = iconUrl;
                Role = role;
            }



            /// <summary>
            /// EF Core constructor
            /// </summary>
            public User() {}
        }
    }
