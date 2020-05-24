using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UMS_Portal.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyCourses()
        {
            return View();
        }
        public ActionResult AvailableCourses()
        {
            return View();
        }
    }
}