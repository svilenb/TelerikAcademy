namespace BullsAndCows.Web.Models
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class GameViewModel
    {
        public static Expression<Func<Game, GameViewModel>> FromGame
        {
            get
            {
                return g => new GameViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Blue = g.BluePlayer.UserName,
                    Red = g.RedPlayer.UserName,
                    GameState = g.GameState.ToString(),
                    DateCreated = g.DateCreated
                };
            }
        }

        public GameViewModel()
        {
        }

        public GameViewModel(Game game)
        {
            this.Id = game.Id;
            this.Name = game.Name;
            this.Red = game.RedPlayer.UserName;
            this.GameState = game.GameState.ToString();
            this.Blue = "No blue player yet";
            this.DateCreated = game.DateCreated;
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public string GameState { get; set; }


        public string Red { get; set; }

        public string Blue { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}