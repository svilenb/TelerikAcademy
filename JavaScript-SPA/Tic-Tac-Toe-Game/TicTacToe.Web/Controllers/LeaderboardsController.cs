namespace TicTacToe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using TicTacToe.Data;
    using TicTacToe.Web.DataModels;
    using TicTacToe.Web.Infrastructure;

    public class LeaderboardsController : BaseApiController
    {
        private const int defaultPageSize = 10;
        private IUserIdProvider userIdProvider;

        //public LeaderboardsController()
        //    : this(new TicTacToeData(new TicTacToeDbContext()), new AspNetUserIdProvider())
        //{
        //}

        public LeaderboardsController(ITicTacToeData data, IUserIdProvider userIdProvider)
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
