using LearningManagementSystem.Config.Results;
using LearningManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.DataAccess.Courses
{
    public class CourseRepository : ICourseRepository
    {
        ApplicationContext _context;
        public CourseRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Course> Add(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task Delete(Guid id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Course?> FirstOrDefault(ICourseRepository.Filter filter)
        {
            return await _context.Courses
                .Include(c => c.Author)
                .Include(c => c.Users)
                .Include(c => c.Lessons)
                .FirstOrDefaultAsync(c => filter(c));
        }

        public async Task<Course?> Get(Guid id)
        {
            return await _context.Courses
                .Include(c => c.Author)
                .Include(c => c.Users)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Course>> GetAll()
        {
            return await _context.Courses
                .Include(c => c.Author)
                .Include(c => c.Users)
                .Include(c => c.Lessons)
                .ToListAsync();
        }

        public async Task<Course?> Update(Guid id, Course course)
        {
            var existingCourse = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCourse == null) return null;

            existingCourse.Name = course.Name;
            existingCourse.Author = course.Author;
            existingCourse.Description = course.Description;

            await _context.SaveChangesAsync();
            return existingCourse;
        }

        public async Task<EnrollUserResult> Enroll(Guid courseId, Guid userId)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) return EnrollUserResult.UserNotFound;
            Course? course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) return EnrollUserResult.CourseNotFound;

            user.EnrolledCourses.Add(course);
            await _context.SaveChangesAsync();
            return EnrollUserResult.Success;
        }

        public async Task<EnrollUserResult> Leave(Guid courseId, Guid userId)
        {
            User? user = await _context.Users
                .Include(u => u.EnrolledCourses)
                .FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) return EnrollUserResult.UserNotFound;
            Course? course = user.EnrolledCourses.Find(c => c.Id == courseId);
            if (course == null) return EnrollUserResult.CourseNotFound;

            user.EnrolledCourses.Remove(course);
            await _context.SaveChangesAsync();
            return EnrollUserResult.Success;
        }

        public async Task<AttachLessonResult> AttachLesson(Guid courseId, Guid lessonId)
        {
            Course? course = await _context.Courses
                .Include(c => c.Lessons)
                .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) return AttachLessonResult.CourseNotFound;
            Lesson? lesson = await _context.Lessons
                .FirstOrDefaultAsync(l => l.Id == lessonId);
            if (lesson == null) return AttachLessonResult.LessonNotFound;
            course.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
            return AttachLessonResult.Success;
        }

        public async Task<AttachLessonResult> DetachLesson(Guid courseId, Guid lessonId)
        {
            Course? course = await _context.Courses
                .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) return AttachLessonResult.CourseNotFound;
            Lesson? lesson = await _context.Lessons
                .FirstOrDefaultAsync(l => l.Id == lessonId);
            if (lesson == null) return AttachLessonResult.LessonNotFound;
            course.Lessons.Remove(lesson);
            return AttachLessonResult.Success;
        }
    }
}
