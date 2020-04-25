using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS_Portal.ViewModels
{
    public class ControllerActionsViewModel
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Attributes { get; set; }
        public string ReturnType { get; set; }
    }
}