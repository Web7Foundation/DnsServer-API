using System.Xml.Linq;

namespace DnsServerAPI;

internal class Record
{

    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#add-record
    /// <summary>
    /// Create a record and return a JSON response from the server.
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
    /// Delete a record and return a JSON response from the server.
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

    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#update-record
    /// <summary>
    /// Update a record and return a JSON response from the server.
    /// </summary>
    internal static async Task<string> Update(
        HttpClient http,
        string token,
        string zone,
        string domain,
        string newDomain,
        string type,
        int ttl,
        string comments,
        bool disable,
        string urlParams)
    {
        if (zone.StartsWith("did:"))
            zone = Utils.ToDNS(zone);

        if (domain.StartsWith("did:"))
            domain = Utils.ToDNS(domain);

        if (newDomain.StartsWith("did:"))
            newDomain = Utils.ToDNS(newDomain);

        var requestUrl = $"/api/zones/records/update?" +
            $"token={token}" +
            $"&zone={zone}" +
            $"&domain={domain}" +
            $"&newDomain={newDomain}" +
            $"&ttl={ttl}" +
            $"&type={type}" +
            $"&disable={disable}" +
            $"&comments={comments}" +
            $"{urlParams}"; // for record specific keys

        // token
        // zone
        // domain
        // type
        // ttl
        // newDomain
        // disable
        // comments



        var req = await http.GetAsync(requestUrl);
        var res = await req.Content.ReadAsStringAsync();

        return Utils.FormatJson(res);
    }

}




