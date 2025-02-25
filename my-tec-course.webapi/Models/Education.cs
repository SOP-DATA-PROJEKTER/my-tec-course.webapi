namespace my_tec_course.webapi.Models
{
    public class Education
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public List<Pathway>? Pathways { get; set; }
    }
}
