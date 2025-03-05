using LearningManagementSystem.Config.Results;
using LearningManagementSystem.DataAccess.Lessons;
using LearningManagementSystem.DataAccess.Models;
using LearningManagementSystem.Dtos;
using LearningManagementSystem.Services.Mappers;

namespace LearningManagementSystem.Services
{
    public class LessonService : ILessonService
    {
        ILessonRepository _lessonRepository;
        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        public async Task<LessonDto> Add(LessonDto lessonDto)
        {
            Lesson lesson = await _lessonRepository.Add(new Lesson
            {
                Name = lessonDto.Name,
                Description = lessonDto.Description,
                Text = lessonDto.Text,
                AttachedFiles = []
            });
            return LessonMapper.LessonToDto(lesson);
        }

        public async Task<AttachFileResult> AttachFile(Guid lessonId, Guid fileId)
        {
            return await _lessonRepository.AttachFile(lessonId, fileId);
        }

        public async Task Delete(Guid id)
        {
            await _lessonRepository.Delete(id);
        }

        public async Task<AttachFileResult> DetachFile(Guid lessonId, Guid fileId)
        {
            return await _lessonRepository.DetachFile(lessonId, fileId);
        }

        public async Task<LessonDto?> Get(Guid id)
        {
            Lesson? lesson = await _lessonRepository.Get(id);
            if (lesson == null) return null;
            return LessonMapper.LessonToDto(lesson);
        }

        public async Task<List<LessonDto>> GetAll()
        {
            List<LessonDto> result = [];
            List<Lesson> lessons = await _lessonRepository.GetAll();
            foreach (Lesson lesson in lessons)
            {
                result.Add(LessonMapper.LessonToDto(lesson));
            }
            return result;
        }

        public async Task<LessonDto?> Update(Guid id, LessonDto lessonDto)
        {
            Lesson? newLesson = await _lessonRepository.Update(id, new Lesson
            {
                Name = lessonDto.Name,
                Description = lessonDto.Description,
                Text = lessonDto.Text,
            });
            if (newLesson == null) return null;
            return LessonMapper.LessonToDto(newLesson);
        }
    }
}
