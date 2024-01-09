using System;
using System.Collections.Generic;

namespace CourseAPI.Models;

public partial class Course: BaseEntity
{

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Overview { get; set; }

    public string? CreateUserId { get; set; }

    public int? Time { get; set; }

    public string? UserId { get; set; }

    public virtual User? CreateUser { get; set; }

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
}
