using LearningManagementSystem.Config;
using LearningManagementSystem.DataAccess;
using LearningManagementSystem.DataAccess.Courses;
using LearningManagementSystem.DataAccess.Lessons;
using LearningManagementSystem.DataAccess.Users;
using LearningManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = AuthConfig.ValidAudience,
            ValidateIssuer = true,
            ValidIssuer = AuthConfig.ValidIssuer,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = AuthConfig.GetSymmetricSecurityKey(),
            ValidateLifetime = true,
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddMvc();

builder.Services.AddDbContext<ApplicationContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();

builder.Services.AddSingleton<IPasswordService, PasswordService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ILessonService, LessonService>();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
