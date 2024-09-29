using System.Security.Cryptography;
using System.Text;

namespace KupujemProdajemClone.Utils;

public class Crypto
{
    public static string CalculateSha256Hash(string input)
    {
        using var sha256Hash = SHA256.Create();

        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hash = sha256Hash.ComputeHash(inputBytes);

        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }

    public static string CalculateMd5Hash(string input)
    {
        using var md5Hash = MD5.Create();

        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hash = md5Hash.ComputeHash(inputBytes);

        return BitConverter.ToString(hash).Replace("-", string.Empty);
    }
}