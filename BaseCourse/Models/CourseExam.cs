using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourse.Models
{
    public class CourseExam : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<UserExam> UserExams { get; set; }
    }
}
