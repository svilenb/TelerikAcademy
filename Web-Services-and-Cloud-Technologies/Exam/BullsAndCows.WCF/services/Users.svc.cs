using BullsAndCows.Data;
using BullsAndCows.WCF.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BullsAndCows.WCF.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Users" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Users.svc or Users.svc.cs at the Solution Explorer and start debugging.
    public class Users : IUsers
    {
        private BullsAndCowsData data;

        public Users()
        {
            this.data = new BullsAndCowsData(BullsAndCowsDbContext.Create());
        }

        public IEnumerable<UserDataModel> GetUsers()
        {
            var users = this.data.Users.All()
                .OrderBy(u => u.UserName)
                .Select(UserDataModel.FromAppUser)
                .ToList();

            return users;
        }
    }
}
