namespace BullsAndCows.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using BullsAndCows.Data;

    public class BaseApiController : ApiController
    {
        protected IBullsAndCowsData data;

        protected BaseApiController(IBullsAndCowsData data)
        {
            this.data = data;
        }
    }
}
