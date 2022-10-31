using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Utils
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            const int iterationCount = 100000;

            const int numBytesRequested = 32;

            byte[] salt = { 1 };

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: iterationCount,
                numBytesRequested: numBytesRequested));

            return hashed;
        }
    }
}