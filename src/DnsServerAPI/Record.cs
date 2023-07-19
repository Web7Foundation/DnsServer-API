using Newtonsoft.Json.Linq;
using TechnitiumLibrary.Net.Dns.ResourceRecords;

namespace DnsServerAPI;

internal class Record
{

    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#add-record
    /// <summary>
    /// returns the json response that is recieved from the server.
    /// </summary>
    public static async Task<string> Add(HttpClient client, string token, string zoneName, string recordType, int ttl, bool overwrite, string comments, string extraUrlParams)
    {
        var requestUrl = $"/api/zones/records/add?" +
            $"token={token}" +
            $"&zone={Utils.AsURIString(zoneName)}" +
            $"&domain={Utils.AsURIString(zoneName)}" +
            $"&type={recordType}" +
            $"&ttl={ttl}" +
            $"&overwrite={overwrite}" +
            $"&comments={Utils.AsURIString(comments)}" +
            $"{extraUrlParams}"; // for record specific keys

        var req = await client.GetAsync(requestUrl);
        var res = await req.Content.ReadAsStringAsync();

        return Utils.FormatJson(res);
    }

    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#get-records
    
    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#delete-record

}


public class JSONKeyMap : TechnitiumLibrary.Net.Dns.ResourceRecords.JSONKeyMap
{
    
}

