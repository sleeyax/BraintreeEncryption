﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace BraintreeEncryption.Lib
{
    public class Aes
    {
        private readonly AesManaged _aesManaged;

        public Aes()
        {
            _aesManaged = new AesManaged {KeySize = 256, BlockSize = 128};
        }

        public byte[] GenerateKey()
        {
            _aesManaged.GenerateKey();
            return _aesManaged.Key;
        }

        private byte[] GenerateIV()
        {
            _aesManaged.GenerateIV();
            return _aesManaged.IV;
        }

        public byte[] Encrypt(string dataToEncrypt, byte[] aesKey)
        {
            return EncryptWithIv(dataToEncrypt, aesKey, GenerateIV());
        }

        private byte[] EncryptWithIv(string dataToEncrypt, byte[] aesKey, byte[] iv)
        {
            var dataInBytes = new UTF8Encoding().GetBytes(dataToEncrypt);

            using (var encryptor = _aesManaged.CreateEncryptor(aesKey, iv))
            {
                var encryptedBytes = encryptor.TransformFinalBlock(dataInBytes, 0, dataInBytes.Length);
                var ivWithEncryptedBytes = new byte[iv.Length + encryptedBytes.Length];

                Buffer.BlockCopy(iv, 0, ivWithEncryptedBytes, 0, iv.Length);
                Buffer.BlockCopy(encryptedBytes, 0, ivWithEncryptedBytes, iv.Length, encryptedBytes.Length);

                return ivWithEncryptedBytes;
            }
        }
    }
}