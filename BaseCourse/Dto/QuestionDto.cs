using BaseCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourse.Dto
{
    public class QuestionDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AnswerDto> AnswerDtos { get; set; }
    }

    public class AnswerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCheck  { get; set; } = false;
    }
}
