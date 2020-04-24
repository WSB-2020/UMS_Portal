using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UMS_Portal.Services.Interfaces;

namespace UMS_Portal.ViewComponents
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IMainDataAccessService _dataAccessService;

        public NavigationMenuViewComponent(IMainDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _dataAccessService.GetMenuItemsAsync(HttpContext.User);

            return View(items);
        }
    }
}