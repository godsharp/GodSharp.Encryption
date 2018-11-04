# GodSharp.Encryption
Common encryption method for .NET.

# Hash Algorithm

- MD5

- SHA
  - SHA1
  - SHA256
  - SHA384
  - SHA512

- HMAC
  - HMACMD5
  - HMACRIPEMD160
  - HMACSHA1
  - HMACSHA256
  - HMACSHA384
  - HMACSHA512

## Method

- Encrypt()

# Symmetric Encryption Algorithm

- AES

- DES

- 3DES

## Method

- Encrypt()

# Asymmetric Encryption Algorithm

- RSA

## Method

- Encrypt()

- Decrypt()

generate openssl key

``` bash
openssl
genrsa -out openssl_rsa_pri_2048.pem 2048
rsa -in openssl_rsa_pri_2048.pem -pubout -out openssl_rsa_pub_2048.pem
```

# Base64

## Method

- Encrypt()

- Decrypt()