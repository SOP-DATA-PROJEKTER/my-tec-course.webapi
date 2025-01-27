namespace my_tec_course.webapi.Models
{
    public class CourseSubject
    {
        // fag
        public int id { get; set; }
        public string name { get; set; }
        public List<Milestone> milestones { get; set; }
        public string teacherName { get; set; }
        public double duration { get; set; }
        public List<CourseTask> courseTasks { get; set; }
        public string roomName { get; set; }

    }
}
