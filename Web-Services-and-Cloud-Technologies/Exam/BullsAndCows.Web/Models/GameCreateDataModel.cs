namespace BullsAndCows.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class GameCreateDataModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required]
        [StringLength(4)]
        //[Column(TypeName = "int")]
        public string Number { get; set; }
    }
}