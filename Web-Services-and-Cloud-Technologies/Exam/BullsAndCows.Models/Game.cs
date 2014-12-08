namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        private ICollection<Guess> guesses;

        public Game()
        {
            this.guesses = new HashSet<Guess>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public GameState GameState { get; set; }

        [Required]
        public string RedPlayerId { get; set; }

        public virtual ApplicationUser RedPlayer { get; set; }

        [Required]
        [StringLength(4)]
        //[Column(TypeName = "int")]
        public string RedPlayerNumber { get; set; }

        public string BluePlayerId { get; set; }

        public virtual ApplicationUser BluePlayer { get; set; }

        [StringLength(4)]
        //[Column(TypeName = "int")]
        public string BluePlayerNumber { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Guess> Guesses
        {
            get
            {
                return this.guesses;
            }
            set
            {
                this.guesses = value;
            }
        }
    }
}
