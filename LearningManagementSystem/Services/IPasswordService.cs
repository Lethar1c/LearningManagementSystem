namespace LearningManagementSystem.Services
{
    public interface IPasswordService
    {
        string HashPassword(string user, string password);
        bool Match(string user, string password, string hash);
    }
}
