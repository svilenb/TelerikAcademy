namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Guess
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [StringLength(4)]
        public string Number { get; set; }

        [Required]
        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}
