using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UMS_Portal.Services.Interfaces;

namespace UMS_Portal.Controllers
{
    public class WidgetsController : Controller
    {

        private readonly IMainDataAccessService _dataS;

        public WidgetsController(
                IMainDataAccessService dataService)
        {
            _dataS = dataService;
        }


        // GET: Widgets
        public ActionResult Index() //TODO: Lista wszystkich widgetów z opisem
        {
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> GetMainMenuAreaAsync()
        {
            var data = await _dataS.GetMenuItemsAsync(User.Identity);
            return PartialView("~/Views/Shared/_MainMenuArea.cshtml", data);
        }

        [HttpGet]
        public async Task<ActionResult> GetMobileMainMenuAreaAsync()
        {
            var data = await _dataS.GetMenuItemsAsync(User.Identity);
            return PartialView("~/Views/Shared/_MobileMenuArea.cshtml", data);
        }
    }
}