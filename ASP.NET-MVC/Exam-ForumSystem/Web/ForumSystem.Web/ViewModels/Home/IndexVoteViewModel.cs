namespace ForumSystem.Web.ViewModels.Home
{
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class IndexVoteViewModel : IMapFrom<Vote>
    {
        public string UserId { get; set; }

        public bool? Value { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}