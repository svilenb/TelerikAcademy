namespace BullsAndCows.Web.Models
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class GameFullViewModel
    {
        public GameFullViewModel(Game game, string userId, string userName)
        {
            this.Id = game.Id;
            this.Name = game.Name;
            this.Red = game.RedPlayer.UserName;
            this.Blue = game.BluePlayer.UserName;
            this.YourNumber = userId == game.BluePlayerId ? game.BluePlayerNumber : game.RedPlayerNumber;
            this.GameState = game.GameState.ToString();
            this.DateCreated = game.DateCreated;
            this.YourGuesses = new List<GuessViewModel>();
            this.OpponentGuesses = new List<GuessViewModel>();
            this.FillYourGuesses(game, userName);
            this.FillOpponentGuesses(game, userName);
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public string GameState { get; set; }

        public string YourColor { get; set; }

        [Required]
        [StringLength(4)]
        public string YourNumber { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public ICollection<GuessViewModel> YourGuesses { get; set; }

        public ICollection<GuessViewModel> OpponentGuesses { get; set; }

        private void FillYourGuesses(Game game, string userName)
        {
            var allGuesses = game.Guesses;

            foreach (var guess in allGuesses)
            {
                if (guess.UserName == userName)
                {
                    this.YourGuesses.Add(new GuessViewModel(guess));
                }
            }
        }

        private void FillOpponentGuesses(Game game, string userName)
        {
            var allGuesses = game.Guesses;

            foreach (var guess in allGuesses)
            {
                if (guess.UserName != userName)
                {
                    this.OpponentGuesses.Add(new GuessViewModel(guess));
                }
            }
        }
    }
}