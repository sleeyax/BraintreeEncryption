# Braintree Client Side Encryption
An updated version of the now deprecated [braintree-encryption](https://github.com/braintree/braintree-encryption.js) javascript library, but written in C#.
This library is also inspired by the much older [braintree_windows_phone_encryption](https://github.com/braintree/braintree_windows_phone_encryption) library.

## Usage
```csharp
string publicKey = "<YOUR_PUBLIC_KEY_HERE>";
string plaintext = "my awesome plaintext string";
var braintree = new Braintree(publicKey);
string encrypted = braintree.Encrypt(plaintext);
// ...
```

## Info
This library is **unofficial** and **not associated with braintree**. 

Go visit the official [website](https://www.braintreepayments.com/) or [github account](https://github.com/braintree) for additional resources.
