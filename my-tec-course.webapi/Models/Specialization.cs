namespace my_tec_course.webapi.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<Course>? Courses { get; set; }
        public required Pathway Pathway { get; set; }
    }
}
