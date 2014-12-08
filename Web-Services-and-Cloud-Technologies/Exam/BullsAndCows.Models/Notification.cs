namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Notification
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Message { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public NotificationType Type { get; set; }

        public NotificationState State { get; set; }

        public int GameId { get; set; }

        [Required]        
        public string ApplicationUserId { get; set; }
    }
}
