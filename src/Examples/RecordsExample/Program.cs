using DnsServerAPI;

const string ADDRESS = "http://localhost:5380";
const string USER = "admin";
const string PASS = "admin";

string token = await Auth.GetLoginToken(ADDRESS, USER, PASS);

Api api = new(ADDRESS, token);


Console.WriteLine("[CREATE TXT RECORD]");
string res = await api.AddRecord("example.did", "TXT", 600, false, "a test comment", "&text=foo");

Console.WriteLine(res);
Console.ReadLine();