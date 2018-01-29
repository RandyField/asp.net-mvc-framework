using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UI.Controllers
{
    public class AwardsController : ApiController
    {
        public class AwardsModel 
        {
            public string bgImg { get; set; }

            public string logoImg { get; set; }

            public string stampcolor { get; set; }
            
            public string awardImg { get; set; }

        }
        public string Get()
        {
            AwardsModel model = new AwardsModel();
            return JsonConvert.SerializeObject(model);
        }
    }
}
