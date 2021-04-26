using Microsoft.AspNetCore.Identity;

namespace GPIHTask.Application.Common.Helper
{
    public static class HashPassword
    {
        public static string Hash(string password)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            return hasher.HashPassword(null, password);
        }

        public static bool Verify(string hashedPassword, string password)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var result = hasher.VerifyHashedPassword(null, hashedPassword, password);

            return result == PasswordVerificationResult.Success;
        }
    }
}
