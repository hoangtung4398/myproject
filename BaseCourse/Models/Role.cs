﻿using System;
using System.Collections.Generic;

namespace BaseCourse.Models
{
    public partial class Role : BaseEntity
    {
        public string? Name { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
