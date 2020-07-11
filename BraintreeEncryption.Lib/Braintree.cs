using System;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto.Macs;

namespace BraintreeEncryption.Lib
{
    public class Braintree
    {
        public string Version { get; } = "1.3.10";
        public string PublicKey { get; set; }
        private readonly Aes _aes;
        private readonly Rsa _rsa;

        public Braintree(string publicKey)
        {
            PublicKey = publicKey;
            _aes = new Aes();
            _rsa = new Rsa(PublicKey);
        }

        private byte[] ConcatByteArrays(byte[] a1, byte[] a2)
        {
            byte[] result = new byte[a1.Length + a2.Length];
            Buffer.BlockCopy(a1, 0, result, 0, a1.Length);
            Buffer.BlockCopy(a2, 0, result, a1.Length, a2.Length);
            return result;
        }
        
        public string Encrypt(string plaintext)
        {
            var aesKey = _aes.GenerateKey();
            var cipher = _aes.Encrypt(plaintext, aesKey);
            var hmac = new HMACSHA256();  // generates hmac with random key
            var signature = hmac.ComputeHash(cipher);
            byte[] combinedKey = ConcatByteArrays(aesKey, hmac.Key);
            var encryptedKey = _rsa.Encrypt(new UTF8Encoding().GetBytes(Convert.ToBase64String(combinedKey)));
            return GetPrefix() + Convert.ToBase64String(encryptedKey) + "$" + Convert.ToBase64String(cipher) + "$" + Convert.ToBase64String(signature);
        }

        private string GetPrefix() => "$bt4|javascript_" + Version.Replace(".", "_") + "$";
    }
}