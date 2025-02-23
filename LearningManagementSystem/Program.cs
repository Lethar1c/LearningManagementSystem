using LearningManagementSystem.DataAccess;
using LearningManagementSystem.DataAccess.Courses;
using LearningManagementSystem.DataAccess.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
