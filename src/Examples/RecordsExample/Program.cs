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
await api.AddRecord("example.did", "111.example.did", "TXT", 600, false, "a test comment", "&text=foo");

// DIDID (the DID value will be the the zoneName value you input ex. 'did:example:111')
await api.AddRecord("did:example:111", "did:example:111", "DIDID", 600, false, null, null);

// DIDPURP
await api.AddRecord("did:example", "did:example:111", "DIDPURP", 600, false, null, "&purpose=the purpose of this is to be an example...");

// DIDCOMM
await api.AddRecord("did:example", "did:example:111", "DIDCOMM", 600, false, null, "&comment=this is a DID comment");

// DIDCTXT
await api.AddRecord("did:example", "did:example:111", "DIDCTXT", 600, false, null, "&context=this is where the 'context' value goes");

// DIDAKA
await api.AddRecord("did:example", "did:example:111", "DIDAKA", 600, false, null, "&alsoKnownAs=the 'AKA' value goes here...");

// DIDCTLR
await api.AddRecord("did:example", "did:example:111", "DIDCTLR", 600, false, null, "&controller=the 'controller' value goes here...");


// This library contains DIDComm objects that you can pass through by doing the following:

// 1. [VERIFICATION METHOD MAP]
// These are the record types you can use for verification method objects:
// note: JsonKeyMap is a class that is contained in a VMM as a property

// DIDVM
// DIDAUTH
// DIDAM
// DIDKA
// DIDCI
// DIDCD

// create the VMM object
VerificationMethodMap vmm = new()
{
    Id = "did:example:111#key-1",
    Controller = "did:example:111",
    Comment = "example comment.",
    Type_ = "Ed25519VerificationKey2018",
    PublicKeyMultibase = "111222333",
    PublicKeyJwk = new JSONKeyMap()
    {
        crv = "crv",
        e = "e",
        n = "n",
        x = "x",
        y = "y",
        kty = "kty",
        kid = "kid",
    },
    PublicKeyBase58 = "11156",
    PrivateKeyBase58 = "abcdefg"
};

// use the ToUri() method to get the url parameters for the verification method map
string s = await api.AddRecord("did:example", "did:example:111", "DIDKA", 600, false, null, vmm.ToUri());

// optional (get output from api)
Console.WriteLine(s);


// 2. [SERVICE MAP]
// These are the record types you can use for service map objects:

// DIDSVC
// DIDREL

// create the SM object
ServiceMap sm = new ServiceMap()
{
    Id = "did:example:111#key-1",
    ServiceEndpoint = "www.google.com",
    Comment = "example comment.",
    Type_ = "Foo",
};

// use ToUri() method like this:
await api.AddRecord("did:example", "did:example:111", "DIDSVC", 600, false, null, sm.ToUri());




// [DELETE RECORD]
// The delete method takes 4 parameters: zone, domain, type, and parameters.
// The url parameters much match an existing record to delete it successfully.
// Functions that were defined above with 'AddRecord()' will be deleted below.

// here is a TXT record example
await api.DeleteRecord("example.did", "111.example.did", "TXT", "&text=foo");

// DIDID (the DID value will be the the zoneName value you input ex. 'did:example:111')
await api.DeleteRecord("did:example:111", "did:example:111", "DIDID", "&did=did:example:111");

// DIDPURP
await api.DeleteRecord("did:example", "did:example:111", "DIDPURP", "&purpose=the purpose of this is to be an example...");

// DIDCOMM
await api.DeleteRecord("did:example", "did:example:111", "DIDCOMM", "&comment=this is a DID comment");

// DIDCTXT
await api.DeleteRecord("did:example", "did:example:111", "DIDCTXT", "&context=this is where the 'context' value goes");

// DIDAKA
await api.DeleteRecord("did:example", "did:example:111", "DIDAKA", "&alsoKnownAs=the 'AKA' value goes here...");

// DIDCTLR
await api.DeleteRecord("did:example", "did:example:111", "DIDCTLR", "&controller=the 'controller' value goes here...");


// Verification Method Map
await api.DeleteRecord("did:example", "did:example:111", "DIDKA", vmm.ToUri());

// Service Map
await api.DeleteRecord("did:example", "did:example:111", "DIDSVC", sm.ToUri());

