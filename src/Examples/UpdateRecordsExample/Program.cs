using DnsServerAPI;
using DnsServerAPI.DIDComm;

const string ADDRESS = "http://localhost:5380";
const string USER = "admin";
const string PASS = "admin";

string token = await Auth.GetLoginToken(ADDRESS, USER, PASS);

Api api = new(token, ADDRESS);

// see https://github.com/Web7Foundation/DnsServer/blob/master/APIDOCS.md#add-record
// for a list of url parameters of all the DNS record types

// [ADD RECORD]

// here is a TXT record example
// await api.UpdateRecord("example.did",
//                        "111.example.did",
//                        "TXT",
//                        "&text=foo");

// DIDID (requires the oldValue parameter to be the same as the domain parameter, in this case: did:example:1234)
await api.UpdateRecord(
    "did:example",
    "did:example:1234",
    "did:example:5555", // <- this will be the new DID
    "DIDID",
    600,
    "",
    false,
    $"&oldValue=did:example:1234"
);

// Single DID values require 2 extra URL parameters (oldValue and newValue)
await api.UpdateRecord(
    "did:example",
    "did:example:1234",
    "did:example:1234",
    "DIDPURP",
    600,
    "",
    false,
    $"&oldValue=a purpose&newValue=a new purpose"
);
