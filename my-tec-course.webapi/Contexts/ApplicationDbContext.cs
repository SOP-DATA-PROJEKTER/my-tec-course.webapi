using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Models;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
    { }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Milestone> Milestones { get; set; }
    public DbSet<Pathway> Pathways { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Subject> Subjects { get; set; }
}