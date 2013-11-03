using System;
using System.Text;

public class EncrypterDecrypter
{
    public static string EncryptDecrypt(string password, string key)
    {
        StringBuilder encryption = new StringBuilder(password.Length);

        for (int index = 0; index < password.Length; index++)
        {
            encryption.Append((char)(password[index] ^ key[index % key.Length]));
        }
        return encryption.ToString();
    }

    public static void Main()
    {
        string key = "mysUpeRseCrEtkeYComBiNATioNiSacTUalLyNoTTHatSeCretATALl";

        string password = "MyPassWord123";

        Console.WriteLine(EncryptDecrypt(password, key));

        Console.WriteLine(EncryptDecrypt(EncryptDecrypt(password, key), key));
    }
}