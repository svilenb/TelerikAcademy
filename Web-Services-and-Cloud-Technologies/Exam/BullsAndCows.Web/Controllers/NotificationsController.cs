namespace BullsAndCows.Web.Controllers
{
    using BullsAndCows.Data;
    using BullsAndCows.Web.Infrastructure;
    using BullsAndCows.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class NotificationsController : BaseApiController
    {
        private const int defaultPageSize = 10;
        private IUserIdProvider userIdProvider;

        public NotificationsController()
            : this(new BullsAndCowsData(), new AspNetUserIdProvider())
        {
        }

        public NotificationsController(IBullsAndCowsData data, IUserIdProvider userIdProvider)
            : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult All(int page = 0)
        {
            var currentUserId = this.userIdProvider.GetUserId();
            var user = this.data.Users.Find(currentUserId);

            var notifications = this.data.Notifications.All().Where(n => n.ApplicationUserId == currentUserId)
                .Select(NotificationViewModel.FromNotification)
                .OrderByDescending(n => n.DateCreated)
                .Skip(page * defaultPageSize)
                .Take(defaultPageSize);

            return Ok(notifications);
        }
    }
}
