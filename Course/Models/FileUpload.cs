using System;
using System.Collections.Generic;

namespace CourseAPI.Models;

public partial class FileUpload
{
    public int? Id { get; set; }

    public string? Url { get; set; }

    public string? Type { get; set; }
}
