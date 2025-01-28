using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Models;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    { }

    public DbSet<UserReflection> UserReflections { get; set; }
    public DbSet<Milestone> Milestones { get; set; }
    public DbSet<EducationType> EducationTypes { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<CourseTask> CourseTasks { get; set; }
    public DbSet<CourseSubject> CourseSubjects { get; set; }
    public DbSet<Course> Courses { get; set; }


}