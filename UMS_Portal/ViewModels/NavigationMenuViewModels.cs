using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS_Portal.ViewModels
{
    public class NavigationMenuViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentMenuId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}