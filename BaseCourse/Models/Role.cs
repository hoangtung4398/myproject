using System;
using System.Collections.Generic;

namespace BaseCourse.Models
{
    public partial class Role : BaseEntity
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public string? Name { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
