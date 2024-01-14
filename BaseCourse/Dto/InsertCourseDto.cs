using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourse.Dto
{
    public class InsertCourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
        public string Requirments { get; set; }
        public string Target { get; set; }
        public string Knowledge { get; set; }
        public int CategoryId {  get; set; }
    }
}
