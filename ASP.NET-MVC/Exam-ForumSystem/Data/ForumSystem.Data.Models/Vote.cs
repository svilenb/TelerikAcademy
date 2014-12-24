namespace ForumSystem.Data.Models
{
    using ForumSystem.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Vote : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public bool? Value { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
