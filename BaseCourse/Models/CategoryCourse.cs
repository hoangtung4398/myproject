using System;
using System.Collections.Generic;

namespace BaseCourse.Models
{
    public partial class CategoryCourse :BaseEntity
    {
        public CategoryCourse()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Urlimage { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
