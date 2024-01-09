using System;
using System.Collections.Generic;

namespace CourseAPI.Models;

public partial class Video : BaseEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public byte[]? Time { get; set; }

    public int? SectionId { get; set; }

    public virtual Section? Section { get; set; }
}
