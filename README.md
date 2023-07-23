# DNS Server API

 Simple API client for [DnsServer](https://github.com/Web7Foundation/DnsServer).

 ## Usage

 ```
using DnsServerAPI;

const string ADDRESS = "http://localhost:5380";
const string USER = "admin";
const string PASS = "admin";

string token = await Auth.GetLoginToken(ADDRESS, USER, PASS);

Api api = new(ADDRESS, token);
```

> See [/src/Examples](https://github.com/Web7Foundation/DnsServer-API/tree/main/src/Examples) for example programs and in-depth usage.

## Features

### Zones
- List zones
- List zone records
- Add zone
- Delete zone

### Records
- Add record
- Delete record

### Dns Client
- Resolve to JSON string

 
