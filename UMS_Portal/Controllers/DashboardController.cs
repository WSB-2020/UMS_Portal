using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UMS_Portal.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View("~/Views/Dashboard/Admin.cshtml");
            }

            return View();
        }
    }
}