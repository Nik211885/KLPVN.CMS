using System.Security.Cryptography;
using System.Text;

namespace KLPVN.Core.Helper;

public static class SecurityHelper
{
  public static string HashPassword(string password, string salt)
  {
    int count = 10000;
    var passwordBytes = Encoding.UTF8.GetBytes(password);
    var saltBytes = Encoding.UTF8.GetBytes(salt);
    var passwordSaltBytes = new byte[saltBytes.Length + passwordBytes.Length];
    Buffer.BlockCopy(passwordBytes, 0, saltBytes, 0, passwordBytes.Length);
    Buffer.BlockCopy(saltBytes, 0, passwordSaltBytes, passwordBytes.Length, salt.Length);
    byte[] hashBytes = passwordSaltBytes;
    for (int i = 0; i < count; i++)
    {
      hashBytes = SHA256.HashData(hashBytes);
    }
    return Convert.ToBase64String(hashBytes);
  }

  public static string GenerateSalt()
    => StringHelper.GeneratorStringBase64(16);
  public static bool VerifyPassword(string password, string salt, string passwordHash)
   => HashPassword(password, salt) == passwordHash;
}
