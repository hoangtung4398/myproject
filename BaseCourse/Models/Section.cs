﻿using System;
using System.Collections.Generic;

namespace BaseCourse.Models
{
    public partial class Section :BaseEntity
    {
        public Section()
        {
            Lectures = new HashSet<Lecture>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
    }
}
