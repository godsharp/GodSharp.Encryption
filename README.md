# GodSharp.Encryption

[![license][li]][l] [![GitHub code size in bytes][si]][0]

Common encryption method for .NET.

# Build Status

|Branch|Status|
|---|---|
|master|[![Build status](https://ci.appveyor.com/api/projects/status/4nyip49ng1agsi3u/branch/master?svg=true&style=flat-square)](https://ci.appveyor.com/project/seayxu/godsharp-encryption/branch/master)|
|dev|[![Build status](https://ci.appveyor.com/api/projects/status/4nyip49ng1agsi3u/branch/dev?svg=true)](https://ci.appveyor.com/project/seayxu/godsharp-encryption/branch/dev)|
|release|[![Build status](https://ci.appveyor.com/api/projects/status/4nyip49ng1agsi3u/branch/release?svg=true)](https://ci.appveyor.com/project/seayxu/godsharp-encryption/branch/release)|

|Name|Stable|Preview|
|---|:---:|:---:|
| GodSharp.Encryption | [![MyGet][mi1]][m1] [![NuGet][ni1]][n1] | [![MyGet][mi2]][m1] [![NuGet][ni2]][n1] |

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

[0]: https://github.com/godsharp/GodSharp.Encryption
[si]: https://img.shields.io/github/languages/code-size/godsharp/GodSharp.Encryption.svg?style=flat-square

[li]: https://img.shields.io/badge/license-MIT-blue.svg?label=license&style=flat-square
[l]: https://github.com/godsharp/GodSharp.Encryption/blob/master/LICENSE

[m1]: https://www.myget.org/Package/Details/godsharp?packageType=nuget&packageId=GodSharp.Encryption

[mi1]: https://img.shields.io/myget/godsharp/v/GodSharp.Encryption.svg?label=myget&style=flat-square
[mi2]: https://img.shields.io/myget/godsharp/vpre/GodSharp.Encryption.svg?label=myget&style=flat-square

[n1]: https://www.nuget.org/packages/GodSharp.Encryption

[ni1]: https://img.shields.io/nuget/v/GodSharp.Encryption.svg?label=nuget&style=flat-square
[ni2]: https://img.shields.io/nuget/vpre/GodSharp.Encryption.svg?label=nuget&style=flat-square