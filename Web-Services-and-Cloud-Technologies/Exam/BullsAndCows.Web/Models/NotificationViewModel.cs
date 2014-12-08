using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BullsAndCows.Web.Models
{
    public class NotificationViewModel
    {
        public static Expression<Func<Notification, NotificationViewModel>> FromNotification
        {
            get
            {
                return n => new NotificationViewModel
                {
                    Id = n.Id,
                    Message = n.Message,
                    DateCreated = n.DateCreated,
                    Type = n.Type.ToString(),
                    State = n.State.ToString(),
                    GameId = n.GameId
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Message { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string Type { get; set; }

        public string State { get; set; }

        public int GameId { get; set; }
    }
}