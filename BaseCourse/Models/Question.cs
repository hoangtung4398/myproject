namespace BaseCourse.Models
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<ResultExam> ResultExams { get; set; } 

    }
}