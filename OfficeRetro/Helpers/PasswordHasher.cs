using System.Security.Cryptography;

namespace OfficeRetro.Helpers;

public class PasswordHasher
{
    private static RandomNumberGenerator RandomGenerator = RandomNumberGenerator.Create();
    private static readonly int SaltSize = 16;
    private static readonly int HashSize = 20;
    private static readonly int Iterations = 1000;

    public static string EncryptPassword(string password)
    {
        var salt = new byte[SaltSize];

        RandomGenerator.GetBytes(salt);

        var key = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA512);

        var hash = key.GetBytes(HashSize);

        var encrypteBytes = new byte[SaltSize + HashSize];

        Array.Copy(salt, 0, encrypteBytes, 0, SaltSize);
        Array.Copy(hash, 0, encrypteBytes, SaltSize, HashSize);

        return Convert.ToBase64String(encrypteBytes);
    }

    public static bool VerifyPassword(string password, string base64Hash)
    {
        var encrypteBytes = Convert.FromBase64String(base64Hash);

        var salt = new byte[SaltSize];

        Array.Copy(encrypteBytes, 0, salt, 0, SaltSize);

        var key = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA512);

        var hash = key.GetBytes(HashSize);

        Array.Copy(encrypteBytes, SaltSize, hash, 0, HashSize);

        var result = true;

        for (var byteIdx = 0; byteIdx < HashSize; byteIdx += 1)
        {
            if (encrypteBytes[SaltSize + byteIdx] != hash[byteIdx])
            {
                result = false;
                break;
            }
        }

        return result;
    }
}
