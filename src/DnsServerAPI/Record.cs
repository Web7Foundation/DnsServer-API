using System.Xml.Linq;

namespace DnsServerAPI;

internal class Record
{

    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#add-record
    /// <summary>
    /// returns the JSON response that is received from the server.
    /// </summary>
    internal static async Task<string> Add(HttpClient http, string token, string zone, string domain, string recordType, int ttl, bool overwrite, string comments, string urlParams)
    {
        if (zone.StartsWith("did:"))
            zone = Utils.ToDNS(zone);

        if (domain.StartsWith("did:"))
            domain = Utils.ToDNS(domain);

        var requestUrl = $"/api/zones/records/add?" +
            $"token={token}" +
            $"&zone={zone}" +
            $"&domain={domain}" +
            $"&type={recordType}" +
            $"&ttl={ttl}" +
            $"&overwrite={overwrite}" +
            $"&comments={comments}" +
            $"{urlParams}"; // for record specific keys


        var req = await http.GetAsync(requestUrl);
        var res = await req.Content.ReadAsStringAsync();

        return Utils.FormatJson(res);
    }


    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#delete-record
    /// <summary>
    /// returns the JSON response that is received from the server.
    /// </summary>
    internal static async Task<string> Delete(HttpClient http, string token, string zone, string domain, string type, string urlParams)
    {
        if (zone.StartsWith("did:"))
            zone = Utils.ToDNS(zone);

        if (domain.StartsWith("did:"))
            domain = Utils.ToDNS(domain);

        var requestUrl = $"/api/zones/records/delete?" +
            $"token={token}" +
            $"&zone={zone}" +
            $"&domain={domain}" +
            $"&type={type}" +
            $"{urlParams}"; // for record specific keys


        var req = await http.GetAsync(requestUrl);
        var res = await req.Content.ReadAsStringAsync();

        return Utils.FormatJson(res);
    }


}




