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
            string[] roles = { "Admin", "Office", "Lecturer", "Student", "Super" };
            string defaultPassword = "Password12#";


            for (int i = 0; i < roles.Length; i++)
            {
                string roleName = roles[i];
                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var role = new IdentityRole { Name = roles[i] };
                    manager.Create(role);
                }

                string newUserEmail = $"{roles[i].ToLower()}@ums.pl";
                if (!context.Users.Any(u => u.Email == newUserEmail))
                {
                    var newUser = new ApplicationUser
                    {
                        Email = newUserEmail,
                        UserName = newUserEmail
                    };
                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore);
                    userManager.Create(newUser, defaultPassword);
                    userManager.AddToRole(newUser.Id, "Admin");
                }
            }


            #endregion

            //#region Default menu items


            //#region Admin
            //NavigationMenu adminMenu_1 = new NavigationMenu
            //{
            //    Name = "Interfejs",
            //    WithoutLinking = true,
            //    IconClass = "notika-icon notika-edit"
            //};
            //context.NavigationMenu.Add(adminMenu_1);
            //context.SaveChanges();

            //NavigationMenu adminMenu_2 = new NavigationMenu
            //{
            //    Name = "U¿ytkownicy",
            //    WithoutLinking = true,
            //    IconClass = "notika-icon notika-edit"
            //};
            //context.NavigationMenu.Add(adminMenu_1);
            //context.SaveChanges();

            //NavigationMenu adminMenu_3 = new NavigationMenu
            //{
            //    Name = "Dane",
            //    WithoutLinking = true,
            //    IconClass = "notika-icon notika-edit"
            //};
            //context.NavigationMenu.Add(adminMenu_1);
            //context.SaveChanges();

            //NavigationMenu adminMenu_4 = new NavigationMenu
            //{
            //    Name = "Raporty",
            //    WithoutLinking = true,
            //    IconClass = "notika-icon notika-edit"
            //};
            //context.NavigationMenu.Add(adminMenu_1);
            //context.SaveChanges();


            //#endregion

            //#region Office


            //#endregion

            //#region Lecturer

            //NavigationMenu lecturerMenu_1 = new NavigationMenu
            //        {
            //            Name = "Moje zajêcia",
            //            WithoutLinking = true,
            //            IconClass = "notika-icon notika-edit"
            //        };
            //        context.NavigationMenu.Add(lecturerMenu_1);
            //        context.SaveChanges();

            //        NavigationMenu lecturerMenu_1_1 = new NavigationMenu
            //        {
            //            Name = "Aktywne zajêcia",
            //            WithoutLinking = true,
            //            IconClass = "notika-icon notika-edit",
            //            ParentMenuId = lecturerMenu_1.Id
            //        };
            //        NavigationMenu lecturerMenu_1_2 = new NavigationMenu
            //        {
            //            Name = "Archiwum",
            //            WithoutLinking = true,
            //            IconClass = "notika-icon notika-edit",
            //            ParentMenuId = lecturerMenu_1.Id
            //        };


            //        NavigationMenu lecturerMenu_2 = new NavigationMenu
            //        {
            //            Name = "Ocenianie",
            //            WithoutLinking = true,
            //            IconClass = "notika-icon notika-edit"
            //        };

            //        context.NavigationMenu.Add(lecturerMenu_2);
            //        context.SaveChanges();

            //        NavigationMenu lecturerMenu_2_1 = new NavigationMenu
            //        {
            //            Name = "Do oceny",
            //            WithoutLinking = true,
            //            IconClass = "notika-icon notika-edit",
            //            ParentMenuId = lecturerMenu_2.Id
            //        };
            //        NavigationMenu lecturerMenu_2_2 = new NavigationMenu
            //        {
            //            Name = "Ocenione",
            //            WithoutLinking = true,
            //            IconClass = "notika-icon notika-edit",
            //            ParentMenuId = lecturerMenu_2.Id
            //        };

            //    #endregion

            //    #region Student

            //#endregion

            //    #region Super

            //#endregion

            //if (!context.NavigationMenu.Any(r => r.Name == "Interfejs"))
            //{
            //    NavigationMenu interfejs = new NavigationMenu
            //    {
            //        Name = "Interfejs",
            //        WithoutLinking = true,
            //        IconClass = "notika-icon notika-edit"
            //    };
            //    context.NavigationMenu.Add(interfejs);
            //    context.SaveChanges();

                

            //    NavigationMenu i_menu = new NavigationMenu
            //    {
            //        Name = "Ustawienia menu",
            //        WithoutLinking = false,
            //        ActionName = "UserMenusConfiguration",
            //        ControllerName = "Admin",
            //        IconClass = "notika-icon notika-form",
            //        ParentMenuId = interfejs.Id
            //    };

            //    NavigationMenu i_ew = new NavigationMenu
            //    {
            //        Name = "Ustawienia wizualne",
            //        WithoutLinking = false,
            //        ActionName = "ThemeConfiguration",
            //        ControllerName = "Admin",
            //        IconClass = "notika-icon notika-app",
            //        ParentMenuId = interfejs.Id
            //    };
            //    context.NavigationMenu.Add(i_ew);
            //    context.NavigationMenu.Add(i_menu);
            //    context.SaveChanges();

            //    RoleMenuPermission rmp = new RoleMenuPermission
            //    {
            //        RoleId = context.Roles.Where(r => r.Name == "Admin").Select(r => r.Id).FirstOrDefault(),
            //        NavigationMenuId = interfejs.Id
            //    };
            //    RoleMenuPermission rmp2 = new RoleMenuPermission
            //    {
            //        RoleId = context.Roles.Where(r => r.Name == "Admin").Select(r => r.Id).FirstOrDefault(),
            //        NavigationMenuId = i_ew.Id
            //    };
            //    RoleMenuPermission rmp3 = new RoleMenuPermission
            //    {
            //        RoleId = context.Roles.Where(r => r.Name == "Admin").Select(r => r.Id).FirstOrDefault(),
            //        NavigationMenuId = i_menu.Id
            //    };
            //    context.RoleMenuPermission.Add(rmp);
            //    context.RoleMenuPermission.Add(rmp2);
            //    context.RoleMenuPermission.Add(rmp3);
                
            //}

            //#endregion


            context.SaveChanges();
        }
    }
}
