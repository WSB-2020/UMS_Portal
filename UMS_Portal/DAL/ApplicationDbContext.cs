using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UMS_Portal.Models;

namespace UMS_Portal.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<RoleMenuPermission> RoleMenuPermission { get; set; }
        public DbSet<NavigationMenu> NavigationMenu { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<UMS_Portal.Models.WalletModel> WalletModels { get; set; }
    }
}