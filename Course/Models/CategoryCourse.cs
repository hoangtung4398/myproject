using System;
using System.Collections.Generic;

namespace CourseAPI.Models;

public partial class CategoryCourse
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Urlimage { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
