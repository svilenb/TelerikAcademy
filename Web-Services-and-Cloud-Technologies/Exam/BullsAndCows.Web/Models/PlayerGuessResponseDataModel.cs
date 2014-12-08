namespace BullsAndCows.Web.Models
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class PlayerGuessResponseDataModel
    {
        public PlayerGuessResponseDataModel(Guess guess)
        {
            this.Id = guess.Id;
            this.UserId = guess.UserId;
            this.UserName = guess.UserName;
            this.GameId = guess.GameId;
            this.Number = guess.Number;
            this.DateMade = guess.DateMade;
            this.BullsCount = guess.BullsCount;
            this.CowsCount = guess.CowsCount;
        }

        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public int GameId { get; set; }

        [Required]
        [StringLength(4)]
        public string Number { get; set; }

        [Required]
        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}