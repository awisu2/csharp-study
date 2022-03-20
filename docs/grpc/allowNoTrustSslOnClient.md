# allow no trust ssl on client

```cs
using System;
using System.Net.Http;
using Grpc.Core;
using Grpc.Net.Client;

// 信頼されていないsslを許可
var httpHandler = new HttpClientHandler();
// Return `true` to allow certificates that are untrusted/invalid
httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

var url = "http://localhost:80";
using var channel = GrpcChannel.ForAddress(url, new GrpcChannelOptions { HttpHandler = httpHandler });
```
