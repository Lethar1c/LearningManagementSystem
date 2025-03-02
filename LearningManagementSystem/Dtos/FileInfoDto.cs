namespace LearningManagementSystem.Dtos
{
    public class FileInfoDto
    {
        public byte[] Bytes { get; set; }
        public string MIMEType { get; set; } = "application/octet-stream";
    }
}
