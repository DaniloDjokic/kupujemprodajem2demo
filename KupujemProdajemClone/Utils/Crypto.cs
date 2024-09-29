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
}