using LearningManagementSystem.Config.Results;
using LearningManagementSystem.Dtos;
using LearningManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonController : ControllerBase
    {
        private ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await _lessonService.GetAll());
        //}

        [HttpGet("{guid}")]
        public async Task<IActionResult> Get(Guid guid)
        {
            LessonDto? course = await _lessonService.Get(guid);
            if (course == null)
            {
                return NotFound($"Lesson with GUID '{guid}' not found in database");
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LessonDto lessonDto)
        {
            LessonDto? newLesson = await _lessonService.Add(lessonDto);
            if (newLesson == null)
            {
                return BadRequest($"Could not create lesson");
            }
            return Ok(newLesson);
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> Update(Guid guid, LessonDto lessonDto)
        {
            LessonDto? updatedLesson = await _lessonService.Update(guid, lessonDto);
            if (updatedLesson == null)
            {
                return NotFound($"Lesson with GUID '{guid}' not found in database");
            }
            return Ok(updatedLesson);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            await _lessonService.Delete(guid);
            return NoContent();
        }

        [HttpPost("attach-file")]
        public async Task<IActionResult> AttachFile(AttachFileDto attachFileDto)
        {
            AttachFileResult result = await _lessonService.AttachFile(attachFileDto.LessonId,
                attachFileDto.FileId);
            switch (result)
            {
                case AttachFileResult.Success:
                    return Ok(result);
                case AttachFileResult.FileNotFound:
                    return BadRequest($"Cannot find file with GUID = {attachFileDto.FileId}");
                case AttachFileResult.LessonNotFound:
                    return BadRequest($"Cannot find user with GUID = {attachFileDto.LessonId}");
                default:
                    return BadRequest("Cannot attach file to a course");
            }
        }

        [HttpPost("detach-file")]
        public async Task<IActionResult> DetachFile(AttachFileDto attachFileDto)
        {
            AttachFileResult result = await _lessonService.DetachFile(attachFileDto.LessonId,
                attachFileDto.FileId);
            switch (result)
            {
                case AttachFileResult.Success:
                    return Ok(result);
                case AttachFileResult.FileNotFound:
                    return BadRequest($"Cannot find file with GUID = {attachFileDto.FileId}");
                case AttachFileResult.LessonNotFound:
                    return BadRequest($"Cannot find user with GUID = {attachFileDto.LessonId}");
                default:
                    return BadRequest("Cannot attach file to a course");
            }
        }
    }
}
