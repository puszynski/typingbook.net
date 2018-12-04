using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TypingMVCApp.Controllers
{
    public class BaseController : Controller
    {
        public const int DefaultPageSize = 20;


        //public int? LoggedUserID()
        //{
        //    var user = LoggedUser();
        //    if (user != null)
        //        return user.ID;

        //    return null;
        //}


        protected string GetBackUrl(string backUrl, string actionName, string controllerName = null)
        {
            if (!string.IsNullOrWhiteSpace(backUrl))
                return backUrl;
            if (controllerName == null)
                return Url.Action(actionName);
            else
                return Url.Action(actionName, controllerName);
        }
    }
}