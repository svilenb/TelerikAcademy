namespace BullsAndCows.Web.Models
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class UserHighScoreViewModel
    {
        public static Expression<Func<ApplicationUser, UserHighScoreViewModel>> FromAppUser
        {
            get
            {
                return u => new UserHighScoreViewModel
                {
                    UserName = u.UserName,
                    UserRank = u.UserRank
                };
            }
        }

        public string UserName { get; set; }

        public int UserRank { get; set; }
    }
}