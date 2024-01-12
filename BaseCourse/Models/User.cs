using System;
using System.Collections.Generic;

namespace BaseCourse.Models
{
    public partial class User :BaseEntity
    {
        public User()
        {
            Courses = new HashSet<Course>();
            UserCourses = new HashSet<UserCourse>();
            Roles = new HashSet<Role>();
        }

        public string Id { get; set; } = null!;
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string? FullName { get; set; }
        public string? AboutMe { get; set; }
        public string? Education { get; set; }
        public string? Experiences { get; set; }
        public string? OverView { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
