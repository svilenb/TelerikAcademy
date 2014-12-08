namespace Music.Web.Controllers
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Music.Data;
    
    public abstract class BaseApiController : ApiController
    {
        protected IMusicData data;

        protected BaseApiController(IMusicData data)
        {
            this.data = data;
        }
    }
}
