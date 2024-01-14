namespace BaseCourse.Models
{
    public class Answer :BaseEntity
    {
        public string Title { get; set; }
        public bool IsRight { get; set; }
        public virtual ICollection<ResultExam> ResultExams { get; set; }
    }
}