using BullsAndCows.WCF.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BullsAndCows.WCF.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsers" in both code and config file together.
    [ServiceContract]
    public interface IUsers
    {

        [OperationContract]
        [WebGet(UriTemplate = "")]
        IEnumerable<UserDataModel> GetUsers();
    }
}
