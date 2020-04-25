using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UMS_Portal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<CourseModel> SupervisedCourses { get; set; }
        public virtual ICollection<CourseModel> ParticipateCourses { get; set; }

        public virtual ICollection<CourseActivity> SupervisedCoursesActivities { get; set; }
        public virtual ICollection<CourseActivity> AttendanceCoursesActivities { get; set; }

        public virtual ICollection<StudentCourseExamData> ExamDatas { get; set; }

        [ForeignKey("Wallet")]
        public string WalletId { get; set; }
        public virtual WalletModel Wallet { get; set; }
    }

    
}