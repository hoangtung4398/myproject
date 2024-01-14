using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCourse.Models
{
    public class UserExam : BaseEntity
    {
        public int Score { get; set; }
        public DateTime AnswerAt { get; set; }
        public virtual ICollection<ResultExam> ResultExams { get; set; }
    }
}
