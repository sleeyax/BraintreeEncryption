using System;
using BraintreeEncryption.Lib;

namespace BraintreeEncryption.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string publicKey = "MIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEAoUID6FPckCjF4YHm8x7pDfoM0YeDx2ZPfdaVs7neGJWHnwYVZpj6X+hg5r8hqazHmFjonN3/SA0CahnN+MLPr4E6cAdUF1eTQnzVfqNVq3lKxYk0twT4Yv7X4oQ2EHYmisFm1A97ujgRwQ5xsbYRHgACe8US1X5S3c7pJDLcM1Ssjr4R3x3/F2e5T7+pWlG/J+tvLRyTvyPuv21KR/ZePHExO1jQ+HYf3gMh1eZfdj2jAPnfPbUSORbOKZtFms8B8ojuGPiSOr5hmBt7gy4UyJDR6tlxhpodqEOpqTv2WfZ/dRoNukETa65eZ0jnmQKnIdXRsNMFUqEF5A4cNVrLhHujwxsOXm5vIeOOWmG/HM8wnltETOF7Fdjs/cXVOicM3d09xL3ePCLe671YjSSb7T7oo/cCI5nK1xzPkQX9q+Yb3OvhoFlF3Mebf94L8te9GCUqt7Dk5Ukrnfn+G53CwH4jeuln2/8lVbE3XFVYT342IGOHpJ+XNbRd9CUTqIH8ESsK0DFeVR3qVCq4zJfQJ9UAKy6tWOHmijIPhpOijWNVgh+HTKUxoloWs3PSWUkOBJUZX4EYUThphCCf8Cedvf2nY0XNwWAmb4FDele8H4/J/NaNFYm/hWK7+Y+DIrL37rLrIb/hjHL1UqaK8osbXQkfohnFVw/pDCuXNemDvJkCAwEAAQ==";
            int cvv = 413;
            
            var braintree = new Braintree(publicKey);
            string encrypted = braintree.Encrypt(cvv.ToString());
            
            Console.WriteLine("Encrypted CVV: " + encrypted);
            Console.ReadKey();
        }
    }
}