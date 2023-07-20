using DnsServerAPI;

const string ADDRESS = "http://localhost:5380";
const string USER = "admin";
const string PASS = "admin";

string token = await Auth.GetLoginToken(ADDRESS, USER, PASS);

Api api = new(ADDRESS, token);


Console.WriteLine("[CREATE TXT RECORD]");

// see https://github.com/Web7Foundation/DnsServer/blob/master/APIDOCS.md#add-record
// for a list of url parameters of all the DNS record types

// here is a TXT record example
//await api.AddRecord("example.did", "TXT", 600, false, "a test comment", "&text=foo");

// DIDID (the DID value will be the the zoneName value you input ex. 'did:example:1234')
//await api.AddRecord("did:example:1234", "DIDID", 600, false, null, null);

// DIDPURP
//await api.AddRecord("did:example", "DIDPURP", 600, false, null, "&purpose=the purpose of this is to be an example...");

// DIDCOMM
//await api.AddRecord("did:example", "DIDCOMM", 600, false, null, "&comment=this is a DID comment");

// DIDCTXT
//await api.AddRecord("did:example", "DIDCTXT", 600, false, null, "&context=this is where the 'context' value goes");

// DIDAKA
//await api.AddRecord("did:example", "DIDAKA", 600, false, null, "&alsoKnownAs=the 'AKA' value goes here...");

// DIDCTLR
//await api.AddRecord("did:example", "DIDCTLR", 600, false, null, "&controller=the 'controller' value goes here...");


// [VERIFICATION METHOD MAP]
// Verification method map DID records follow a different pattern.
// These are the record types for verification methods:

// DIDVM
// DIDAUTH
// DIDAM
// DIDKA
// DIDCI
// DIDCD

// create the verification method map object
DnsServerAPI.DIDComm.VerificationMethodMap vmm = new()
{
    Id = "did:example:1234#key-1",
    Controller = "did:example:1234",
    Comment = "example comment.",
    Type_ = "Ed25519VerificationKey2018",
    PublicKeyMultibase = "111222333",
    PublicKeyJwk = new DnsServerAPI.DIDComm.JSONKeyMap()
    {
        crv = "crv",
        e = "e",
        n = "n",
        x = "x",
        y = "y",
        kty = "kty",
        kid = "kid",
    },
    PublicKeyBase58 = "123456",
    PrivateKeyBase58 = "abcdefg"
};

// pass the vmm object into this method, it will parse all the properties into a URI string for the api
string s = await api.ADDRecordVMM("did:example", "did:example:111", "DIDKA", 600, false, "comment", vmm);

Console.WriteLine(s);

