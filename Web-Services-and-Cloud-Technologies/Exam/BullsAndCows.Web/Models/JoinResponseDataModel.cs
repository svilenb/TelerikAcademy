namespace BullsAndCows.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class JoinResponseDataModel
    {
        public JoinResponseDataModel(string gameName)
        {
            this.Result = "You joined game " + "\"" + gameName + "\"";
        }

        [Required]
        public string Result { get; set; }
    }
}