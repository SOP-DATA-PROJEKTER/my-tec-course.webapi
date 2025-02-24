using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
using my_tec_course.webapi.Models;
using my_tec_course.webapi.Repositories;
using my_tec_course.webapi.Services;

var builder = WebApplication.CreateBuilder(args);


// database context

// SQL Server database from appsettings.Development.json & Datacontext
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Add services to the container.


builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// add repository injection
builder.Services.AddScoped<IGenericCrudRepository<Course>, CourseRepository>();
builder.Services.AddScoped<IGenericCrudRepository<Education>, EducationRepository>();
builder.Services.AddScoped<IGenericCrudRepository<Milestone>, MilestoneRepository>();
builder.Services.AddScoped<IGenericCrudRepository<Pathway>, PathwayRepository>();
builder.Services.AddScoped<IGenericCrudRepository<Specialization>, SpecializationRepository>();
builder.Services.AddScoped<IGenericCrudRepository<Subject>, SubjectRepository>();


// add service injection
builder.Services.AddScoped<IGenericCrudService<Course>, CourseService>();
builder.Services.AddScoped<IGenericCrudService<Education>, EducationService>();
builder.Services.AddScoped<IGenericCrudService<Milestone>, MilestoneService>();
builder.Services.AddScoped<IGenericCrudService<Pathway>, PathwayService>();
builder.Services.AddScoped<IGenericCrudService<Specialization>, SpecializationService>();
builder.Services.AddScoped<IGenericCrudService<Subject>, SubjectService>();



// Cors Rules
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapIdentityApi<IdentityUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
