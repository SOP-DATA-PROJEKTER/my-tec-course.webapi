namespace my_tec_course.webapi.Models
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public string courseType { get; set; }
        public List<CourseSubject> courseSubjects { get; set; }
    }
}
