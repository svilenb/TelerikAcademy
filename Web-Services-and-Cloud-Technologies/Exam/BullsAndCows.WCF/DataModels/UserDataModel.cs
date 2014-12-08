namespace BullsAndCows.WCF.DataModels
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class UserDataModel
    {
        public static Expression<Func<ApplicationUser, UserDataModel>> FromAppUser
        {
            get
            {
                return a => new UserDataModel
                {
                    Id = a.Id,
                    UserName = a.UserName
                };
            }
        }

        public string Id { get; set; }

        public string UserName { get; set; }
    }
}