namespace CourseAPI.Models.Dto
{
    public class SectionDto
    {
        public string? Name { get; set; }

        public virtual ICollection<VideoDto> Videos { get; set; } = new List<VideoDto>();
    }
}
