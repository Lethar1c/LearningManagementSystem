namespace LearningManagementSystem.Dtos
{
    public class FileDto
    {
        public byte[] Bytes { get; set; }
        public string MIMEType { get; set; } = "application/octet-stream";
    }
}
