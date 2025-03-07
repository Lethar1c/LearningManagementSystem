﻿using LearningManagementSystem.Config.Results;
using LearningManagementSystem.DataAccess.Models;

namespace LearningManagementSystem.DataAccess.Courses
{
    public interface ICourseRepository
    {
        delegate bool Filter(Course course);

        Task<Course?> FirstOrDefault(Filter filter);
        Task<Course?> Get(Guid id);
        Task<List<Course>> GetAll();
        Task<Course> Add(Course course);
        Task<Course?> Update(Guid id, Course user);
        Task Delete(Guid id);
        Task<EnrollUserResult> Enroll(Guid courseId, Guid userId);
        Task<EnrollUserResult> Leave(Guid courseId, Guid userId);
        Task<AttachLessonResult> AttachLesson(Guid courseId, Guid lessonId);
        Task<AttachLessonResult> DetachLesson(Guid courseId, Guid lessonId);
    }
}
