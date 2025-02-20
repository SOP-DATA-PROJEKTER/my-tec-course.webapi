using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Models;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    { }

    DbSet<Course> Courses { get; set; }
    DbSet<Education> Educations { get; set; }
    DbSet<Milestone> Milestones { get; set; }
    DbSet<Pathway> Pathways { get; set; }
    DbSet<Specialization> Specializations { get; set; }
    DbSet<Subject> Subjects { get; set; }
}