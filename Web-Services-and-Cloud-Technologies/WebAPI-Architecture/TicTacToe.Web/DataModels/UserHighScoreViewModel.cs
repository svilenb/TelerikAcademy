using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TicTacToe.Models;

namespace TicTacToe.Web.DataModels
{
    public class UserHighScoreViewModel
    {
        public static Expression<Func<User, UserHighScoreViewModel>> FromAppUser
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