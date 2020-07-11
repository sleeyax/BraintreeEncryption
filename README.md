# Braintree Client Side Encryption
An updated version of the now deprecated [braintree-encryption](https://github.com/braintree/braintree-encryption.js) JavaScript library, but written in C#.
Inspired by the much older [braintree_windows_phone_encryption](https://github.com/braintree/braintree_windows_phone_encryption) library.

## Usage
Example code:
```csharp
string publicKey = "<YOUR_PUBLIC_KEY_HERE>";
string plaintext = "my awesome plaintext string";
var braintree = new Braintree(publicKey);
string encrypted = braintree.Encrypt(plaintext);
Console.WriteLine(encrypted);
// output:
// $bt4|javascript_1_3_10$JveMakLz30cPoV0j2W6B7V1IMwnerOXMAi3PGVuuqaiPjq+ku4W9vDZMjcXeXrdMC7z2yMWUBzHPBWtS9hxzaE7HMja3aJ/8UF2k39vcYEsDf3t0XS/fpioifJpPexJ8b6ZJ8Z1h1JLdr4IF6QPP29Io9q4zWRiaF2mX
   TadTz0McTjwLaWyT1/gYvT6oeh2DHB1B9bKkJeMILKJCL8NguJ3+bt0EMF8PYX5CnMIg5LGpdV0hBAvo0EPos8NZdTUp52wNdIzSOT8axebjPalh8aa4AY7B93xcBpr/1WyNhqPwucmZ3VB9GxoDZKg8dXRlaInQ69+Va4HHGrLgRGwzkzIDqnYiE2+AXAySJsUdD+muAV
   9QsjhduUTaI7PrU8ANYk+KgRJsa1jFCfuiQjxLwl1iSTNtZ4Rdqn4YalPBcSR280pWxr/+e5EGPuxAsGXgqkyiECkPXWdpZ5kLdagXGBMOPaE7on054wUFWT0S7zWx/Ard+tTFztrJm4Yd/rGW6vNaf3HQqu7kEm+T1197nLLKxA7IECjgvTewLEPDkOgfZs8Qj88WBQzO
   xK3gKF5ObA4D9T0WIvNQWveCan9zTkNZ0TgbuWjckBGp6/IA4mtheThFxCK8iXyoWWyOH+sRWgi4TXXULRS1v6me8+ykIKYI3nQCXuanx8tZZPO9rWE=$pm139N2eIDbO49KKD+rVZ9ci91Zt2588T+5IQrfaGjw=$4/dkxF229bilffEs+2XTmC10OJdQT2hUKnB3UZkZ
   neE=
```

## Info
This library is **unofficial** and **not associated with braintree**. 

Go visit the official [website](https://www.braintreepayments.com/) or [github account](https://github.com/braintree) for additional resources.
