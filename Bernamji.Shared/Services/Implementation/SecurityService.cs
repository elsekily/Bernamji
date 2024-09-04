using Bernamji.Shared.Services.Core;
using System.Security.Cryptography;
using System.Text;

namespace Bernamji.Shared.Services.Implementation;

public class SecurityService : ISecurityService
{
    private readonly byte[] salt = Encoding.UTF8.GetBytes("MySaltValue12345");
    private readonly int iterations = 1000;
    public string HashPassword(string password)
    {
        // Generate a random salt
        byte[] salt = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }

        // Hash the password with the salt
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPasswordBytes = new byte[passwordBytes.Length + salt.Length];
        Buffer.BlockCopy(passwordBytes, 0, saltedPasswordBytes, 0, passwordBytes.Length);
        Buffer.BlockCopy(salt, 0, saltedPasswordBytes, passwordBytes.Length, salt.Length);
        byte[] hashedBytes = new SHA512Managed().ComputeHash(saltedPasswordBytes);
        string hashedPassword = Convert.ToBase64String(hashedBytes);

        // Append the salt to the end of the hash
        string saltString = Convert.ToBase64String(salt);
        return hashedPassword + saltString;
    }
    public bool CheckPassword(string password, string hashedPasswordWithSalt)
    {
        // Extract the hash and salt from the hashed password string
        string hashedPassword = hashedPasswordWithSalt.Substring(0, hashedPasswordWithSalt.Length - 24);
        string saltString = hashedPasswordWithSalt.Substring(hashedPasswordWithSalt.Length - 24);

        // Convert the salt from a string to a byte array
        byte[] salt = Convert.FromBase64String(saltString);

        // Hash the password with the salt and compare to the stored hash
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPasswordBytes = new byte[passwordBytes.Length + salt.Length];
        Buffer.BlockCopy(passwordBytes, 0, saltedPasswordBytes, 0, passwordBytes.Length);
        Buffer.BlockCopy(salt, 0, saltedPasswordBytes, passwordBytes.Length, salt.Length);
        byte[] hashedBytes = new SHA512Managed().ComputeHash(saltedPasswordBytes);
        string hashedPasswordToCheck = Convert.ToBase64String(hashedBytes);
        return hashedPasswordToCheck == hashedPassword;
    }
}
