namespace BullsAndCows.Web.Models
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class GuessViewModel
    {
        public GuessViewModel(Guess guess)
        {
            this.Id = guess.Id;
            this.UserId = guess.UserId;
            this.GameId = guess.GameId;
            this.Number = guess.Number;
            this.DateMade = guess.DateMade;
            this.CowsCount = guess.CowsCount;
            this.BullsCount = guess.BullsCount;
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