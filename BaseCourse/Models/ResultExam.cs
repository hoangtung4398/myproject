using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourse.Models
{
    public class ResultExam:BaseEntity
    {
        public Answer? Answer { get; set; }
        public DateTime? TakeAt { get; set; }
    }
}
