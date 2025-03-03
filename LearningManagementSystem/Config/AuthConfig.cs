using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LearningManagementSystem.Config
{
    public static class AuthConfig
    {
        const string _key = "my-super-secret-security-key-1000-7-la-la-la-la-la";
        public const string ValidAudience = "LMS_Aud";
        public const string ValidIssuer = "LMS_Iss";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        }
    }
}
