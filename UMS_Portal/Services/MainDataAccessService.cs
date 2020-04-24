using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using UMS_Portal.DAL;
using UMS_Portal.Services.Interfaces;
using UMS_Portal.ViewModels;

namespace UMS_Portal.Services
{
    public class MainDataAccessService : IMainDataAccessService
    {
        private readonly ApplicationDbContext _db;
        public MainDataAccessService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<List<NavigationMenuViewModel>>GetMenuItemsAsync(ClaimsPrincipal principal)
        {
            var isAuthenticated = principal.Identity.IsAuthenticated;
            if (!isAuthenticated)
                return new List<NavigationMenuViewModel>();

            var roleIds = await GetUserRoleIds(principal);
            var data = await (from menu in _db.RoleMenuPermission
                              where roleIds.Contains(menu.RoleId)
                              select menu)
                              .Select(m => new NavigationMenuViewModel()
                              {
                                  Id = m.NavigationMenu.Id,
                                  Name = m.NavigationMenu.Name,
                                  ActionName = m.NavigationMenu.ActionName,
                                  ControllerName = m.NavigationMenu.ControllerName,
                                  ParentMenuId = m.NavigationMenu.ParentMenuId,
                              }).Distinct().ToListAsync();

            return data;
        }

        private async Task<List<string>> GetUserRoleIds(ClaimsPrincipal ctx)
        {
            var userId = GetUserId(ctx);
            var data = await _db.Roles
                .Where(r => r.Users.Any(u => u.UserId == userId))
                .Select(r=>r.Id)
                .ToListAsync();

            return data;
        }

        private string GetUserId(ClaimsPrincipal user)
        {
            return ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}