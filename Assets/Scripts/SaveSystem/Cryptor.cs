using System.IO;
using System.Security.Cryptography;
using System;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    //todo rename
    public static class Cryptor // Everything besides constructor is a copypaste from here https://learn.microsoft.com/ru-ru/dotnet/api/system.security.cryptography.cryptostream?view=net-8.0
    {
        private static const string KEY = "CryptingKey";
        private static const string IV = "CryptingIV";
        private static readonly byte[] _byteKey;
        private static readonly byte[] _byteIV;

        static Cryptor()
        {
            // Checking if there's key and IV
            if (PlayerPrefs.HasKey(KEY) && PlayerPrefs.HasKey(IV))
            {
                _byteKey = PlayerPrefs.GetString(KEY).Split(" ");
                _byteIV = PlayerPrefs.GetString(IV).Split(" ");
            }
            else // Creating new key and IV if there's none
            {
                using (Aes myAes = Aes.Create())
                {
                    _byteKey = myAes.Key;
                    _byteIV = myAes.IV;
                }

                var keySB = new StringBuilder();                
                for (int i = 0; i < _byteKey.Length - 1; i++)
                {
                    keySB.Append(_byteKey[i] + " ");
                }
                keySB.Append(bytedState.Last());

                var IVSB = new StringBuilder();
                for (int i = 0; i < _byteIV.Length - 1; i++)
                {
                    IVSB.Append(_byteIV[i] + " ");
                }
                IVSB.Append(bytedState.Last());
                
                // Setting in prefs as new key and IV
                PlayerPrefs.SetString(KEY, keySB.ToString());
                PlayerPrefs.SetString(IV, IVSB.ToString());
            }
        }

        public static byte[] EncryptStringToBytes(string plainText)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException(nameof(plainText));
            if (_byteKey == null || _byteKey.Length <= 0)
                throw new ArgumentNullException(nameof(_byteKey));
            if (_byteIV == null || _byteIV.Length <= 0)
                throw new ArgumentNullException(nameof(_byteIV));
            byte[] encrypted;

            // Create a Aes object with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _byteKey;
                aesAlg.IV = _byteIV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new())
                {
                    using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new(csEncrypt))
                        {
                            // Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public static string DecryptStringFromBytes(byte[] cipherText)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException(nameof(cipherText));
            if (_byteKey == null || _byteKey.Length <= 0)
                throw new ArgumentNullException(nameof(_byteKey));
            if (_byteIV == null || _byteIV.Length <= 0)
                throw new ArgumentNullException(nameof(_byteIV));

            // Declare the string used to hold the decrypted text.
            string plaintext = null;

            // Create a Aes object with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _byteKey;
                aesAlg.IV = _byteIV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new(cipherText))
                {
                    using (CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}