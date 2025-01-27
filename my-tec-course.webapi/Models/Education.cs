namespace my_tec_course.webapi.Models
{
    public class Education
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Course> courses { get; set; }

    }
}
