namespace TicTacToe.Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using TicTacToe.Models;

    public class GameInfoModel
    {
        public static Expression<Func<Game, GameInfoModel>> FromGame
        {
            get
            {
                return g => new GameInfoModel
                {
                    Id = g.Id,
                    FirstPlayerName = g.FirstPlayer.UserName
                };
            }
        }

        public Guid Id { get; set; }

        public string FirstPlayerName { get; set; }
    }
}