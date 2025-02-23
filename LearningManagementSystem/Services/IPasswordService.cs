namespace LearningManagementSystem.Services
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool Match(string password, string hash);
    }
}
