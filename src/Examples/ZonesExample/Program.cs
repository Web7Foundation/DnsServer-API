using DnsServerAPI;

const string ADDRESS = "http://localhost:5380";
const string USER = "admin";
const string PASS = "admin";

string token = await Auth.GetLoginToken(ADDRESS, USER, PASS);

Api api = new(ADDRESS, token);

var listofzones = await api.ListZones();

Console.WriteLine("[LIST ZONES]");
foreach (var z in listofzones)
{
    Console.WriteLine(z);
}

var records = await api.ListZoneRecords("example.com");

Console.WriteLine("\n[LIST RECORDS]");
foreach (var r in records)
{
    Console.WriteLine(r);
}

await Task.Delay(1000);

bool added = await api.AddZone("myexamplezone1234.com");

if (added) Console.WriteLine("\nZone Added Successfully...");

await Task.Delay(1000);

bool deleted = await api.DeleteZone("myexamplezone1234.com");

if (deleted) Console.WriteLine("Zone Deleted Successfully...");
