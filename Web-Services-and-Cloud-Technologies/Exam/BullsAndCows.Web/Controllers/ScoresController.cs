namespace BullsAndCows.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using BullsAndCows.Data;
    using BullsAndCows.Web.Infrastructure;
    using BullsAndCows.Web.Models;

    public class ScoresController : BaseApiController
    {
        private const int defaultPageSize = 10;
        private IUserIdProvider userIdProvider;

        public ScoresController()
            : this(new BullsAndCowsData(), new AspNetUserIdProvider())
        {
        }

        public ScoresController(IBullsAndCowsData data, IUserIdProvider userIdProvider)
            : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        [HttpGet]
        public IHttpActionResult TopTen()
        {
            var users = this.data.Users.All()
                .Select(UserHighScoreViewModel.FromAppUser).OrderByDescending(u => u.UserRank)
                .ThenBy(u => u.UserName).Take(defaultPageSize);

            return Ok(users);
        }
    }
}
