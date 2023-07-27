using DnsServerAPI;

const string ADDRESS = "http://127.0.0.1:5380";
const string USER = "admin";
const string PASS = "admin";

string token = await Auth.GetLoginToken(ADDRESS, USER, PASS);

Api api = new(token, ADDRESS);

// This method will return a JSON response from the server
string res = await api.DnsClientResolveToJson("did:example:111", "DIDSIG", "this-server", Protocol.Tcp);
Console.WriteLine("[RESOLVE TO JSON]\n");
Console.WriteLine(res);

// You can use only the domain parameter as the rest will be defaulted:
string res2 = await api.DnsClientResolveToJson("did:example:111");
Console.WriteLine("\n[RESOLVE TO JSON] (default parameters)\n");
Console.WriteLine(res2);