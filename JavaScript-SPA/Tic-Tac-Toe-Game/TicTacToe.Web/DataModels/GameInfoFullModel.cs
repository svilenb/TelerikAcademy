namespace TicTacToe.Web.DataModels
{
    using System;
    using System.Linq.Expressions;
    using TicTacToe.Models;

    public class GameInfoFullModel
    {
        public static Expression<Func<Game, GameInfoFullModel>> FromGame
        {
            get
            {
                return g => new GameInfoFullModel
                {
                    Id = g.Id,
                    FirstPlayerName = g.FirstPlayer.UserName,
                    SecondPlayerName = g.SecondPlayer.UserName,
                    State = g.State,
                    Board = g.Board
                };
            }
        }

        public Guid Id { get; set; }

        public string Board { get; set; }

        public string FirstPlayerName { get; set; }

        public string SecondPlayerName { get; set; }

        public GameState State { get; set; }
    }
}