using Microsoft.AspNetCore.Identity;

namespace LearningManagementSystem.Services
{
    public class PasswordService : IPasswordService
    {
        readonly PasswordHasher<string> _passwordHasher;
        public PasswordService()
        {
            _passwordHasher = new PasswordHasher<string>();
        }

        public string HashPassword(string user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool Match(string user, string password, string hash)
        {
            return _passwordHasher.VerifyHashedPassword(user, hash, password) == PasswordVerificationResult.Success;
        }
    }
}
