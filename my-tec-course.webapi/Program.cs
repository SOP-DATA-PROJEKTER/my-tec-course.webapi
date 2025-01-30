using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using my_tec_course.webapi.Interfaces.Repositories;
using my_tec_course.webapi.Interfaces.Services;
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

builder.Services.AddScoped<IUserReflectionRepository, UserReflectionRepository>();
builder.Services.AddScoped<IMilestoneRepository, MilestoneRepository>();
builder.Services.AddScoped<IEducationTypeRepository, EducationTypeRepository>();
builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<ICourseSubjectRepository, CourseSubectRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IGetAllRepository, GetAllRepository>();

// add service injection
builder.Services.AddScoped<IUserReflectionService, UserReflectionService>();
builder.Services.AddScoped<IMilestoneService, MilestoneService>();
builder.Services.AddScoped<IEducationTypeService, EducationTypeService>();
builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<ICourseSubjectService, CourseSubjectService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IGetAllService, GetAllService>();

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


builder.Services.AddControllers();
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
