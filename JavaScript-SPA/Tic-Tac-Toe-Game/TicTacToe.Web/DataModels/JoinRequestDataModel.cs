namespace TicTacToe.Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class JoinRequestDataModel
    {
        [Required]
        public string GameId { get; set; }
    }
}