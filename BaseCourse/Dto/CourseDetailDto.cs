using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourse.Dto
{
    public class CourseDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requirments { get; set; }
        public string Target { get; set; }
        public string Knowledge { get; set; }
        public int LectureCount { get; set; }
        public string ImageUrl { get; set; }
        public int EnrollmentsCount { get; set; }
        public Instructor CreateUser { get; set; }
        public ICollection<SectionDto> Sections { get; set; }


    }
    public class SectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LectureCount { get; set; }
        public ICollection<LectureDto> Lectures { get; set; }
    }
    public class LectureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string AboutMe { get; set; }
        public int CourseCount { get; set; }
    }
}
