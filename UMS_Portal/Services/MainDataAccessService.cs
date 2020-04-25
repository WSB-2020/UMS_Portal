using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using UMS_Portal.DAL;
using UMS_Portal.Models;
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

        public async Task<List<NavigationMenuViewModel>>GetMenuItemsAsync(IIdentity principal)
        {
            var isAuthenticated = principal.IsAuthenticated;
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
                                  IconClass = m.NavigationMenu.IconClass,
                                  WithoutLinking = m.NavigationMenu.WithoutLinking
                              }).Distinct().ToListAsync();

            return data;
        }

        private async Task<List<string>> GetUserRoleIds(IIdentity ctx)
        {
            var userId = ctx.GetUserId();
            var data = await _db.Roles
                .Where(r => r.Users.Any(u => u.UserId == userId))
                .Select(r=>r.Id)
                .ToListAsync();

            return data;
        }

        public async Task<bool> AddMenuItem(NavigationMenuViewModel vm) //TODO: dodać uprawnienia roli!!!!
        {
            try
            {
                NavigationMenu menuItem = new NavigationMenu
                {
                    Name = vm.Name,
                    WithoutLinking = vm.WithoutLinking,
                    ActionName = vm.ActionName,
                    ControllerName = vm.ControllerName,
                    IconClass = vm.IconClass
                };
                var parent = await _db.NavigationMenu.FindAsync(vm.ParentMenuId);
                if (parent != null)
                {
                    menuItem.ParentMenuId = parent.Id;
                }
                _db.NavigationMenu.Add(menuItem);
                await _db.SaveChangesAsync();

                var adminRole = await _db.Roles.Where(r => r.Name == "Admin").FirstOrDefaultAsync();
                if (adminRole != null)
                {
                    RoleMenuPermission rmp = new RoleMenuPermission
                    {
                        RoleId = adminRole.Id,
                        NavigationMenuId = menuItem.Id
                    };
                    _db.RoleMenuPermission.Add(rmp);
                    await _db.SaveChangesAsync();
                }


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

    }
}