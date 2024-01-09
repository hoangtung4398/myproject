using System;
using System.Collections.Generic;

namespace CourseAPI.Models;

public partial class Section :BaseEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CourseId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Video> Videos { get; set; } = new List<Video>();
}
