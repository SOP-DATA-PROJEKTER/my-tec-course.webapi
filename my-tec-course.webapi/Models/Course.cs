namespace my_tec_course.webapi.Models
{
    // Forløb
    public class Course
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<Subject>? Subjects { get; set; } = new();
        public Specialization? Specialization { get; set; }
        public int SpecializationId { get; set; }

    }
}
