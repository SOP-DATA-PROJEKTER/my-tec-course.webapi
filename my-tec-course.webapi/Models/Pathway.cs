namespace my_tec_course.webapi.Models
{
    public class Pathway
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<Specialization>? Specializations { get; set; } = new();
        public Education? Education { get; set; }
        public int EducationId { get; set; }
    }
}
