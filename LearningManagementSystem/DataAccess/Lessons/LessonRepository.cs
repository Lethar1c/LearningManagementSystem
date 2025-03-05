using LearningManagementSystem.Config.Results;
using LearningManagementSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.DataAccess.Lessons
{
    public class LessonRepository : ILessonRepository
    {
        private ApplicationContext _context;
        public LessonRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Lesson> Add(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
            return lesson;
        }

        public async Task<AttachFileResult> AttachFile(Guid lessonId, Guid fileId)
        {
            Models.File? file = await _context.Files.FirstOrDefaultAsync(f => f.Id == fileId);
            if (file == null) return AttachFileResult.FileNotFound;
            Lesson? lesson = await Get(lessonId);
            if (lesson == null) return AttachFileResult.LessonNotFound;
            lesson.AttachedFiles.Add(file);
            await _context.SaveChangesAsync();
            return AttachFileResult.Success;
        }

        public async Task Delete(Guid id)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == id);
            if (lesson != null)
            {
                _context.Lessons.Remove(lesson);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<AttachFileResult> DetachFile(Guid lessonId, Guid fileId)
        {
            Lesson? lesson = await _context.Lessons
                .Include(l => l.AttachedFiles)
                .FirstOrDefaultAsync(l => l.Id == lessonId);
            if (lesson == null) return AttachFileResult.LessonNotFound;
            Models.File? file = await _context.Files.FirstOrDefaultAsync(f => f.Id == fileId);
            if (file == null) return AttachFileResult.FileNotFound;

            lesson.AttachedFiles.Remove(file);
            await _context.SaveChangesAsync();
            return AttachFileResult.Success;
        }

        public async Task<Lesson?> Get(Guid id)
        {
            return await _context.Lessons
                .Include(l => l.AttachedFiles)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Lesson>> GetAll()
        {
            return await _context.Lessons
                .Include(l => l.AttachedFiles)
                .ToListAsync();
        }

        public async Task<Lesson?> Update(Guid id, Lesson lesson)
        {
            var existingLesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == id);
            if (existingLesson == null) return null;

            existingLesson.Name = lesson.Name;
            existingLesson.Text = lesson.Text;
            existingLesson.Description = lesson.Description;

            await _context.SaveChangesAsync();
            return existingLesson;
        }
    }
}
