using LearningManagementSystem.Dtos;
using LearningManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("{guid}")]
        public IActionResult Get(string guid)
        {
            FileDto? fileDto = _fileService.Get(guid);
            if (fileDto == null) { return NotFound(); }
            return File(fileDto.Bytes, fileDto.MIMEType);
        }

        [HttpPost]
        public ActionResult Upload(IFormFile file)
        {
            bool result = _fileService.Upload(file);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
