using System;
using System.Numerics;
using System.Text;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;

namespace BraintreeEncryption.Lib
{
    public class Rsa
    {
        private readonly string _publicKeyString;

        public Rsa(string publicKeyString)
        {
            _publicKeyString = publicKeyString;
        }

        public byte[] Encrypt(byte[] dataToEncrypt)
        {
            var rsaKeyParameters = GetRsaKeyParameters(_publicKeyString);
            var rsaEngine = new Pkcs1Encoding(new RsaEngine());
            rsaEngine.Init(true, rsaKeyParameters);
            return rsaEngine.ProcessBlock(dataToEncrypt, 0, dataToEncrypt.Length);
        }

        /// <summary>
        /// Reads a base64 and ASN.1 DER-encoded public key and returns its RSA key parameters
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">thrown when the public key is malformed</exception>
        private RsaKeyParameters GetRsaKeyParameters(string encodedPublicKey)
        {
            var rawPublicKeyBytes= Convert.FromBase64String(encodedPublicKey);
            var inputStream = new Asn1InputStream(rawPublicKeyBytes);
            
            var sequence = Asn1Sequence.GetInstance(inputStream.ReadObject());
            
            var publicKeyInfo = SubjectPublicKeyInfo.GetInstance(sequence);
            var publicKeySequence = Asn1Sequence.GetInstance(publicKeyInfo.GetPublicKey());

            if (publicKeySequence.Count != 2) 
                throw new Exception("expected public key to contain a modulus and an exponent");
            
            var modulus = new Org.BouncyCastle.Math.BigInteger(publicKeySequence[0].ToString());
            var exponent = new Org.BouncyCastle.Math.BigInteger(publicKeySequence[1].ToString());
            
            return new RsaKeyParameters(false, modulus, exponent);
        }
    }
}