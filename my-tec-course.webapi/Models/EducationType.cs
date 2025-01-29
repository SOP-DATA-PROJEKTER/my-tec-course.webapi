namespace my_tec_course.webapi.Models
{
    public class EducationType
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Education> educations { get; set; }

    }
}
