namespace UMS_Portal.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UMS_Portal.DAL;
    using UMS_Portal.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "UMS_Portal.DAL.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            #region Default Users and Roles

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Office"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var role = new IdentityRole { Name = "Office" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Lecturer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var role = new IdentityRole { Name = "Lecturer" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Super"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var role = new IdentityRole { Name = "Super" };
                manager.Create(role);
            }

            List<ApplicationUser> users = new List<ApplicationUser>
            {
                new ApplicationUser {
                    Email = "admin@ums.pl",
                    UserName ="admin@ums.pl" },
                new ApplicationUser {
                    Email = "office@ums.pl",
                    UserName = "office@ums.pl" },
                new ApplicationUser {
                    Email = "lecturer@ums.pl",
                    UserName ="lecturer@ums.pl"}
            };

            foreach (var newUser in users)
            {
                if (!context.Users.Any(u => u.Email == newUser.Email))
                {
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    manager.Create(newUser, "password12#");
                    if (newUser.Email == "admin@ums.pl")
                    {
                        manager.AddToRole(newUser.Id, "Admin");
                    }
                    if (newUser.Email == "office@ums.pl")
                    {
                        manager.AddToRole(newUser.Id, "Office");
                    }
                    if (newUser.Email == "lecturer@ums.pl")
                    {
                        manager.AddToRole(newUser.Id, "Lecturer");
                    }
                }
            }

            #endregion

            #region Default menu items

            if (!context.NavigationMenu.Any(r => r.Name == "Interfejs"))
            {
                NavigationMenu interfejs = new NavigationMenu
                {
                    Name = "Interfejs",
                    WithoutLinking = true,
                    IconClass = "notika-icon notika-edit"
                };
                context.NavigationMenu.Add(interfejs);
                context.SaveChanges();

                

                NavigationMenu i_menu = new NavigationMenu
                {
                    Name = "Ustawienia menu",
                    WithoutLinking = false,
                    ActionName = "UserMenusConfiguration",
                    ControllerName = "Admin",
                    IconClass = "notika-icon notika-form",
                    ParentMenuId = interfejs.Id
                };

                NavigationMenu i_ew = new NavigationMenu
                {
                    Name = "Ustawienia wizualne",
                    WithoutLinking = false,
                    ActionName = "ThemeConfiguration",
                    ControllerName = "Admin",
                    IconClass = "notika-icon notika-app",
                    ParentMenuId = interfejs.Id
                };
                context.NavigationMenu.Add(i_ew);
                context.NavigationMenu.Add(i_menu);
                context.SaveChanges();

                RoleMenuPermission rmp = new RoleMenuPermission
                {
                    RoleId = context.Roles.Where(r => r.Name == "Admin").Select(r => r.Id).FirstOrDefault(),
                    NavigationMenuId = interfejs.Id
                };
                RoleMenuPermission rmp2 = new RoleMenuPermission
                {
                    RoleId = context.Roles.Where(r => r.Name == "Admin").Select(r => r.Id).FirstOrDefault(),
                    NavigationMenuId = i_ew.Id
                };
                RoleMenuPermission rmp3 = new RoleMenuPermission
                {
                    RoleId = context.Roles.Where(r => r.Name == "Admin").Select(r => r.Id).FirstOrDefault(),
                    NavigationMenuId = i_menu.Id
                };
                context.RoleMenuPermission.Add(rmp);
                context.RoleMenuPermission.Add(rmp2);
                context.RoleMenuPermission.Add(rmp3);
                
            }

            #endregion


            context.SaveChanges();
        }
    }
}
