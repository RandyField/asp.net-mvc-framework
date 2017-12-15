using Common.WebHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        public void ClearSession()
        {
            SessionHelper.Del("Account");
        }

    }
}
