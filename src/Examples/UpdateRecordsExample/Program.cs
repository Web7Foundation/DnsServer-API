using DnsServerAPI;
using DnsServerAPI.DIDComm;

const string ADDRESS = "http://localhost:5380";
const string USER = "admin";
const string PASS = "admin";

string token = await Auth.GetLoginToken(ADDRESS, USER, PASS);

Api api = new(token, ADDRESS);

// see https://github.com/Web7Foundation/DnsServer/blob/master/APIDOCS.md#update-record
// for a list of url parameters of all the DNS record types

// here is how a TXT record can be updated
await api.UpdateRecord("example.did",
                       "111.example.did",
                       "333.example.did",
                       "TXT",
                       600,
                       "",
                       false,
                       "&text=foo");

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

#region Verification Method Map

// Updating a Verification Method Map

// old vmm
VerificationMethodMap vmm = new()
{
    Id = "did:example:111#key-1",
    Controller = "did:example:111",
    Comment = "example comment.",
    Type_ = "Ed25519VerificationKey2018",
    keyPublicJsonWebKey = "{ \"foo\": 123 }",
    keyPublicJsonWebKeyString = "{ \"bar\": 456 }",
    publicKeyMultibase = "{ \"hello\": \"world\" }",
    publicKeyJwk = "{ \"numbers\": \"123456789\" }",
};

// new vmm
VerificationMethodMap newVmm = new()
{
    Id = "did:example:5555#key-1",
    Controller = "did:example:5555",
    Comment = "example comment.",
    Type_ = "Ed25519VerificationKey2018",
    keyPublicJsonWebKey = "{ \"updatedFoo\": 123 }",
    keyPublicJsonWebKeyString = "{ \"updatedBar\": 456 }",
    publicKeyMultibase = "{}",
    publicKeyJwk = "{}",
};

// update by calling 'ToUpdateUri' and passing the new vmm as a parameter
await api.UpdateRecord(
    "did:example",
    "did:example:111",
    "did:example:5555",
    "DIDVM",
    600,
    "",
    false,
    vmm.ToUpdateUri(newVmm));

#endregion

#region Service Map

// Updating a Service Map

// old service map
ServiceMap sm = new ServiceMap()
{
    Id = "did:example:111#key-1",
    ServiceEndpoint = "www.google.com",
    Comment = "example comment.",
    Type_ = "Foo",
};

// use ToUri() method like this:
await api.AddRecord("did:example", "did:example:111", "DIDSVC", 600, false, null, sm.ToUri());

// old service map
ServiceMap newSm = new ServiceMap()
{
    Id = "did:example:5555#key-1",
    ServiceEndpoint = "www.youtube.com",
    Comment = $"This was updated at {DateTime.Now.ToShortTimeString()}",
    Type_ = "Bar",
};

// update by calling 'ToUpdateUri' and passing the new service map as a parameter
await api.UpdateRecord(
    "did:example",
    "did:example:111",
    "did:example:5555",
    "DIDSVC",
    600,
    "",
    false,
    sm.ToUpdateUri(newSm));

#endregion