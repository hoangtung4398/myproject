using System;
using System.Collections.Generic;

namespace CourseAPI.Models;

public partial class UserCourse : BaseEntity
{ 
    public string UserId { get; set; } = null!;

    public int CourseId { get; set; }

    public DateTime? CreateAt { get; set; }

    public int? Status { get; set; }


    public virtual Course Course { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
