using System;
using System.Collections.Generic;

namespace BaseCourse.Models
{
    public partial class Course :BaseEntity
    {
        public Course()
        {
            Sections = new HashSet<Section>();
            UserCourses = new HashSet<UserCourse>();
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Requirments { get; set; }
        public int CreateUserId { get; set; }
        public int? Time { get; set; }
        public string? Target { get; set; }
        public string? Knowledge { get; set; }
        public int? CategoryId { get; set; }
        public string? ImageUrl { get; set; }

        public virtual CategoryCourse? Category { get; set; }
        public virtual User? CreateUser { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
