using BackendTechnicalAssetsManagement.src.IService;

namespace BackendTechnicalAssetsManagement.src.Services
{
    public class PasswordHashingService : IPasswordHashingService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(string password, string hash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hash))
                return false;
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
