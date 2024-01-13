using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaseCourse.Models
{
    public partial class CategoryCourse :BaseEntity
    {
        public CategoryCourse()
        {
            Courses = new HashSet<Course>();
        }
        public string? Name { get; set; }
        public string? Urlimage { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
