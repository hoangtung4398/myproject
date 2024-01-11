namespace CourseAPI.Models.Dto
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Requirments { get; set; }

        public string? CreateUserId { get; set; }

        public int? Time { get; set; }

        public string? UserId { get; set; }

        public string? Target { get; set; }

        public string? Knowledge { get; set; }

        public int? CategoryId { get; set; }

        public virtual ICollection<SectionDto> Sections { get; set; } = new List<SectionDto>();
    }
}
