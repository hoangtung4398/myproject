using System;
using System.Collections.Generic;

namespace BaseCourse.Models
{
    public partial class User :BaseEntity
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? AboutMe { get; set; }
        public string? Education { get; set; }
        public string? Experiences { get; set; }
        public string? OverView { get; set; }
        public string? Job { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
