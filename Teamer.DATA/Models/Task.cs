using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teamer.DATA.Models.Enums;

namespace Teamer.DATA.Models
{
    public class Task
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Extra { get; set; }
        public string? IconUrl { get; set; }
        public Status Status { get; set; } = Status.Unknown;
        public DateTime Started { get; set; }
        public DateTime? DeadLine { get; set; }
        public TimeSpan TimeLeft
        {
            get
            {
                if (DeadLine.HasValue) return DeadLine.Value - DateTime.Now;
                return default(TimeSpan);
            }
        }
        #endregion

        public Task(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(Title));
            Status = Status.InProgress;
            Started = DateTime.Now;
        }

        public Task(string title, string? description, string? extra, DateTime? deadLine, string? iconUrl)
            : this(title)
        {
            Description = description;
            Extra = extra;
            DeadLine = deadLine;
            IconUrl = iconUrl;
        }

        public override string ToString()
        {
            return Title;
        }

        /// <summary>
        /// EF Core constructor
        /// </summary>
        public Task() { }
    }
}
