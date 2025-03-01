using LearningManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

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
            IFileInfo? fileInfo = _fileService.Get(guid);
            if (fileInfo == null) { return NotFound(); }
            byte[] fileBytes = System.IO.File.ReadAllBytes(fileInfo.PhysicalPath);
            return File(fileBytes, "image/jpeg");
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
