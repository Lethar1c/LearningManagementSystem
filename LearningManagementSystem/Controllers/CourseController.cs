using LearningManagementSystem.Config.Results;
using LearningManagementSystem.Dtos;
using LearningManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _courseService.GetAll());
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(Guid guid)
        {
            CourseDto? course = await _courseService.Get(guid);
            if (course == null)
            {
                return NotFound($"Course with GUID '{guid}' not found in database");
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCourseDto course)
        {
            CourseDto? newCourse = await _courseService.Add(course);
            if (newCourse == null)
            {
                return BadRequest($"Could not create course");
            }
            return Ok(newCourse);
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> Update(Guid guid, UpdateCourseDto courseDto)
        {
            CourseDto? updatedCourse = await _courseService.Update(guid, courseDto);
            if (updatedCourse == null)
            {
                return NotFound($"Course with GUID '{guid}' not found in database");
            }
            return Ok(updatedCourse);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            await _courseService.Delete(guid);
            return NoContent();
        }



        [HttpPost("enroll")]
        public async Task<IActionResult> Enroll(EnrollStudentDto dto)
        {
            EnrollUserResult result = await _courseService.Enroll(dto.CourseId, dto.UserId);
            switch (result)
            {
                case EnrollUserResult.Success:
                    return Ok();
                case EnrollUserResult.CourseNotFound:
                    return BadRequest($"Cannot find course with GUID = {dto.CourseId}");
                case EnrollUserResult.UserNotFound:
                    return BadRequest($"Cannot find user with GUID = {dto.UserId}");
                default:
                    return BadRequest("Cannot enroll student to a course");
            }
        }

        [HttpDelete("leave")]
        public async Task<IActionResult> Leave(EnrollStudentDto dto)
        {
            EnrollUserResult result = await _courseService.Leave(dto.CourseId, dto.UserId);
            switch (result)
            {
                case EnrollUserResult.Success:
                    return Ok();
                case EnrollUserResult.CourseNotFound:
                    return BadRequest($"Cannot find course with GUID = {dto.CourseId}");
                case EnrollUserResult.UserNotFound:
                    return BadRequest($"Cannot find user with GUID = {dto.UserId}");
                default:
                    return BadRequest("Cannot leave student to a course");
            }
        }

        [HttpPost("attach-lesson")]
        public async Task<IActionResult> AttachLesson(AttachLessonDto dto)
        {
            AttachLessonResult result = await _courseService.AttachLesson(dto.CourseId, dto.LessonId);
            switch (result)
            {
                case AttachLessonResult.Success:
                    return Ok();
                case AttachLessonResult.CourseNotFound:
                    return BadRequest($"Cannot find course with id = {dto.CourseId}");
                case AttachLessonResult.LessonNotFound:
                    return BadRequest($"Cannot find lesson with id = {dto.LessonId}");
                default:
                    return BadRequest("Cannot attach lesson to a course");
            }
        }

        [HttpPost("detach-lesson")]
        public async Task<IActionResult> DetachLesson(AttachLessonDto dto)
        {
            AttachLessonResult result = await _courseService.DetachLesson(dto.CourseId, dto.LessonId);
            switch (result)
            {
                case AttachLessonResult.Success:
                    return Ok();
                case AttachLessonResult.CourseNotFound:
                    return BadRequest($"Cannot find course with id = {dto.CourseId}");
                case AttachLessonResult.LessonNotFound:
                    return BadRequest($"Cannot find lesson with id = {dto.LessonId}");
                default:
                    return BadRequest("Cannot detach lesson to a course");
            }
        }
    }
}
