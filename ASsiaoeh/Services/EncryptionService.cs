/*
using System;
using System.IO;
using System.Security.Cryptography;

namespace ASsiaoeh.Services
{
    public class EncryptionService
    {
        private readonly byte[] _encryptionKey;

        // Constructor to initialize the encryption key
        public EncryptionService()
        {
            // Retrieve the encryption key securely (e.g., from environment variables)
            //string encryptionKeyString = Environment.GetEnvironmentVariable("ENCRYPTION_KEY");

            // Check if the encryption key is null or empty, or has invalid length
            //if (string.IsNullOrEmpty(encryptionKeyString) || encryptionKeyString.Length % 4 != 0)
            //{
            //    throw new InvalidOperationException("Invalid encryption key.");
            //}

            //try
            //{
                // Convert the encryption key string from Base64 to byte array
            //    _encryptionKey = Convert.FromBase64String(encryptionKeyString);
            //}
            //catch (FormatException)
            //{
                // Handle the case where the encryption key has invalid format
            //    throw new InvalidOperationException("Invalid encryption key format.");
            //}
        }

        // Method to encrypt data
        public string EncryptData(string data)
        {
            byte[] encryptedBytes;
            //using (Aes aesAlg = Aes.Create())
            //{
                // Set the encryption key and generate a new IV (Initialization Vector)
            //    aesAlg.Key = _encryptionKey;
            //    aesAlg.GenerateIV();

                // Create an encryptor object using AES encryption algorithm
            //    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create a memory stream to write the encrypted data
            //    using (MemoryStream msEncrypt = new MemoryStream())
            //    {
                    // Create a CryptoStream to perform the encryption
            //        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            //        {
                        // Create a StreamWriter to write the plaintext data to the CryptoStream
            //            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            //            {
                        // Write the plaintext data to the CryptoStream
            //                swEncrypt.Write(data);
            //            }
                        // Get the encrypted data bytes from the memory stream
            //            encryptedBytes = msEncrypt.ToArray();
            //        }
            //    }
            //}

            // Convert the encrypted bytes to Base64 string and return
            return ""; //Convert.ToBase64String(encryptedBytes);
        }

        // Method to decrypt data
        public string DecryptData(string encryptedData)
        {
            // Convert the Base64 string to byte array
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

            //using (Aes aesAlg = Aes.Create())
            //{
                // Set the encryption key and generate a new IV (Initialization Vector)
            //    aesAlg.Key = _encryptionKey;
            //    aesAlg.GenerateIV();

                // Create a decryptor object using AES encryption algorithm
            //    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create a memory stream to read the encrypted data
            //    using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
            //    {
                    // Create a CryptoStream to perform the decryption
            //        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            //        {
                        // Create a StreamReader to read the decrypted data from the CryptoStream
            //            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            //            {
                            // Read the decrypted data and return as plaintext
            //                return srDecrypt.ReadToEnd();
            //            }
            //        }
            //    }
            return ""; // No decryption performed
        }
    }
}
*/
