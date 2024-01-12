using System;
using System.Collections.Generic;

namespace BaseCourse.Models
{
    public partial class Lecture :BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public int? SectionId { get; set; }
        public TimeSpan? Time { get; set; }
        public string? NameFileAzure { get; set; }

        public virtual Section? Section { get; set; }
    }
}
