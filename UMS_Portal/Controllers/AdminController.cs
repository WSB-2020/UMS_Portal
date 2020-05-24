using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UMS_Portal.Services.Interfaces;
using UMS_Portal.ViewModels;

namespace UMS_Portal.Controllers
{
    public class AdminController : Controller
    {

        private readonly IMainDataAccessService _dataS;

        public AdminController(
                IMainDataAccessService dataService)
        {
            _dataS = dataService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }        

        public ActionResult ManualDataBackup()
        {
            return View();
        }

        // GET: Admin
        public async Task<ActionResult> Users()
        {
            return View(await _dataS.GetUserList());
        }

        public ActionResult ThemeConfiguration()
        {
            return View();
        }

        public ActionResult UserMenusConfiguration()
        {
            return View();
        }

        public ActionResult ControllerActionsList()
        {
            //Assembly asm = Assembly.GetExecutingAssembly();
            //IEnumerable<MethodInfo> data = asm.GetTypes()
            //    .Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
            //    .SelectMany(type => type.GetMethods())
            //    .Where(method => method.IsPublic 
            //    && !method.IsDefined(typeof(NonActionAttribute))
            //    && method.ReturnType == typeof(ActionResult));

            Assembly asm = Assembly.GetExecutingAssembly();
            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new {
                        Controller = x.DeclaringType.Name,
                        Action = x.Name,
                        ReturnType = x.ReturnType.Name,
                        Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", "")))
                    })
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
            var list = new List<ControllerActionsViewModel>();
            foreach (var item in controlleractionlist)
            {
                list.Add(new ControllerActionsViewModel()
                {
                    Controller = item.Controller,
                    Action = item.Action,
                    Attributes = item.Attributes,
                    ReturnType = item.ReturnType
                });
            }


            return View(list);
        }

        public ActionResult AddMenuItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddMenuItem(NavigationMenuViewModel vm)
        {
            return await _dataS.AddMenuItem(vm) && ModelState.IsValid ? View() : View(vm);
        }
    }
}