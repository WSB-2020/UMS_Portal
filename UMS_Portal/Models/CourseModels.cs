using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMS_Portal.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AdditionalInfo { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }

        [ForeignKey("Supervisor")]
        public string SupervisorId { get; set; }
        [InverseProperty("SupervisedCourses")]
        public virtual ApplicationUser Supervisor { get; set; }

        [InverseProperty("ParticipateCourses")]
        public virtual ICollection<ApplicationUser> CourseStudents { get; set; }

        public virtual ICollection<CourseModule> Modules { get; set; }
        public virtual ICollection<AccountOperation> CourseFees { get; set; }

        [ForeignKey("CourseExams")]
        public int CourseExamsId { get; set; }
        public virtual ICollection<CourseExam> CourseExams { get; set; }
    }

    public class CourseModule
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual CourseModel Course { get; set; }
    }

    public class CourseActivity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AdditionalInfo { get; set; }
        public bool OnlineMeeting { get; set; }
        public string Address { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateStop { get; set; }

        [ForeignKey("CourseModule")]
        public int CourseModuleId { get; set; }
        public virtual CourseModule CourseModule { get; set; }

        [ForeignKey("Supervisor")]
        public string SupervisorId { get; set; }
        [InverseProperty("SupervisedCoursesActivities")]
        public virtual ApplicationUser Supervisor { get; set; }

        [InverseProperty("AttendanceCoursesActivities")]
        public virtual ICollection<ApplicationUser> Attendance { get; set; }
    }

    public class CourseExam
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime DateOpen { get;set; }
        public int LengthInMinutes { get; set; }
        public bool IsOnline { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual CourseModel Course { get; set; }
        public virtual ICollection<StudentCourseExamData> StudentCourseExamData { get; set; }
    }

    public class StudentCourseExamData
    {
        public int Id { get; set; }
        public bool Passed { get; set; }
        public double ExamResult { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual ApplicationUser Student { get; set; }

        [ForeignKey("CourseExam")]
        public int CourseExamId { get; set; }
        public virtual CourseExam CourseExam { get; set; }
    }
}