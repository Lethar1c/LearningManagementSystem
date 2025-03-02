
using LearningManagementSystem.Config;
using LearningManagementSystem.DataAccess;
using LearningManagementSystem.Dtos;
using Microsoft.Extensions.FileProviders;
using Models = LearningManagementSystem.DataAccess.Models;

namespace LearningManagementSystem.Services
{
    public class FileService : IFileService
    {
        private ApplicationContext _context;
        public FileService(ApplicationContext context)
        {
            _context = context;
        }

        private static string GetExtension(IFormFile file)
        {
            return Path.GetExtension(file.FileName);
        }
        public void Delete(Guid fileId)
        {
            Delete(fileId.ToString());
        }

        public void Delete(string fileId)
        {
            Models.File? file = _context.Files.FirstOrDefault(f => f.Id.ToString() == fileId);
            if (file == null) return;
            string path = file.Path;
            System.IO.FileInfo fileInfo = new(path);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                _context.Files.Remove(file);
                _context.SaveChanges();
            }
        }

        public FileInfoDto? Get(Guid fileId)
        {
            return Get(fileId.ToString());
        }

        public FileInfoDto? Get(string fileId)
        {
            Models.File? file = _context.Files.FirstOrDefault(f => f.Id.ToString().ToUpper() == fileId.ToUpper());
            if (file == null) return null;
            PhysicalFileProvider fileProvider = new(Directory.GetCurrentDirectory());
            IFileInfo fileInfo = fileProvider.GetFileInfo(file.Path);
            string extension = Path.GetExtension(fileInfo.Name);
            if (fileInfo.Exists)
            {
                if (fileInfo == null) { return null; }
                byte[] fileBytes = System.IO.File.ReadAllBytes(fileInfo.PhysicalPath);
                return new FileInfoDto
                {
                    Bytes = fileBytes,
                    MIMEType = FileConfig.GetFileInfo(extension)?.MIMEType ?? "application/octet-stream"
                };
            }
            return null;
        }

        public bool Upload(IFormFile? file)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));
            string extention = GetExtension(file);
            Config.FileInfo? fileInfo = FileConfig.GetFileInfo(extention);
            if (fileInfo == null) return false;
            if (file.Length > fileInfo.MaxSize) return false;
            Guid id = Guid.NewGuid();
            string fileName = id.ToString() + extention;
            string fileStreamPath = Path.Combine(Directory.GetCurrentDirectory(), "files");
            string filePath = Path.Combine("files", fileName);
            using (FileStream fileStream = new(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            _context.Files.Add(new Models.File
            {
                Id = id,
                Name = fileName,
                Path = filePath
            });
            _context.SaveChanges();
            return true;
        }
    }
}
