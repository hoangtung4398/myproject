using System;
using System.Collections.Generic;

namespace BaseCourse.Models
{
    public partial class Lecture :BaseEntity
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public int? SectionId { get; set; }
        public TimeSpan? Time { get; set; }
        public string? NameFileAzure { get; set; }
        public int? Sort {  get; set; }
        public virtual Section? Section { get; set; }
        public virtual ICollection<Document>? Documents { get; set; }
    }
}
