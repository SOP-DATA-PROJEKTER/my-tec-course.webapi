namespace my_tec_course.webapi.Models
{
    // Fag
    public class Subject
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<Milestone>? Milestones { get; set; } = new();
        public required Course Course { get; set; }
    }
}
