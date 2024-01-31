using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourse.Dto
{
    public class SearchListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int EnrollmentsCount { get; set; }
        public int LectureCount { get; set; }
        public InstructorDto instructorDto { get; set; }
    }
}
