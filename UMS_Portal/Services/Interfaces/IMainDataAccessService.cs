using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UMS_Portal.ViewModels;

namespace UMS_Portal.Services.Interfaces
{
    public interface IMainDataAccessService
    {
        Task<List<NavigationMenuViewModel>> GetMenuItemsAsync(ClaimsPrincipal principal);
    }
}
