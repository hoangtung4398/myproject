using System;
using System.Collections.Generic;

namespace CourseAPI.Models;

public partial class FileUpload : BaseEntity
{

    public string? NameAz { get; set; }

    public string? NameClient { get; set; }

    public string? Url { get; set; }

    public string? FileType { get; set; }
}
