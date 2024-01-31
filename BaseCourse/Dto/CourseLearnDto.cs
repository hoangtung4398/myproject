using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourse.Dto
{
    public class CourseLearnDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public InstructorDto Instructor { get; set; }
    }

    public class InstructorDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Avatar { get; set; }
    }
}
