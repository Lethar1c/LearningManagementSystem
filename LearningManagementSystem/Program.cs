using LearningManagementSystem.DataAccess;
using LearningManagementSystem.DataAccess.Courses;
using LearningManagementSystem.DataAccess.Users;
using LearningManagementSystem.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddDbContext<ApplicationContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddSingleton<IPasswordService, PasswordService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IFileService, FileService>();


var app = builder.Build();

app.MapControllers();

app.Run();
