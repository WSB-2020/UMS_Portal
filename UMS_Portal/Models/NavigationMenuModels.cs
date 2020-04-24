using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace UMS_Portal.Models
{
    [Table(name: "AspNetRoleMenuPermission")]
    public class RoleMenuPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("ApplicationRole")]
        public string RoleId { get; set; }

        [ForeignKey("NavigationMenu")]
        public Guid NavigationMenuId { get; set; }

        public NavigationMenu NavigationMenu { get; set; }

        public virtual IdentityRole ApplicationRole { get; set; }
    }

    [Table(name: "AspNetNavigationMenu")]
    public class NavigationMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("ParentNavigationMenu")]
        public Guid? ParentMenuId { get; set; }

        public virtual NavigationMenu ParentNavigationMenu { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string IconClass { get; set; }

        public bool WithoutLinking { get; set; }

        [NotMapped]
        public bool Permitted { get; set; }
    }

}
