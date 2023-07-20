using Newtonsoft.Json.Linq;
using TechnitiumLibrary.Net.Dns.ResourceRecords;

namespace DnsServerAPI;

internal class Record
{

    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#add-record
    /// <summary>
    /// returns the json response that is recieved from the server.
    /// </summary>
    internal static async Task<string> Add(HttpClient client, string token, string zoneName, string recordType, int ttl, bool overwrite, string comments, string extraUrlParams)
    {
        if (zoneName.StartsWith("did:"))
            zoneName = Utils.ToDNS(zoneName);

        // change to custom content type

        var requestUrl = $"/api/zones/records/add?" +
            $"token={token}" +
            $"&zone={zoneName}" +
            $"&domain={zoneName}" +
            $"&type={recordType}" +
            $"&ttl={ttl}" +
            $"&overwrite={overwrite}" +
            $"&comments={comments}" +
            $"{extraUrlParams}"; // for record specific keys

        var req = await client.GetAsync(requestUrl);
        var res = await req.Content.ReadAsStringAsync();

        return Utils.FormatJson(res);
    }

    internal static async Task<string> AddVMM(HttpClient client, string token, string zoneName, string subjectDid, string recordType, int ttl, bool overwrite, string comments, DIDComm.VerificationMethodMap vmm)
    {
        if (zoneName.StartsWith("did:"))
            zoneName = Utils.ToDNS(zoneName);

        if (subjectDid.StartsWith("did:"))
            subjectDid = Utils.ToDNS(subjectDid);

        // change http content type

        var requestUrl = $"/api/zones/records/add?" +
            $"token={token}" +
            $"&zone={zoneName}" +
            $"&domain={subjectDid}" +
            $"&type={recordType}" +
            $"&ttl={ttl}" +
            $"&overwrite={overwrite}" +
            $"&comments={comments}" +
            vmm.AsApiUrl();

        var req = await client.GetAsync(requestUrl);
        var res = await req.Content.ReadAsStringAsync();

        return Utils.FormatJson(res);
    }

    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#get-records

    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#delete-record

}




