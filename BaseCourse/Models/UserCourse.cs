using System;
using System.Collections.Generic;

namespace BaseCourse.Models
{
    public partial class UserCourse : BaseEntity
    {
        public int UserId { get; set; } 
        public int CourseId { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? Status { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
