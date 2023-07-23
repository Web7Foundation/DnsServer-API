namespace DnsServerAPI;

internal class Record
{

    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#add-record
    /// <summary>
    /// returns the json response that is recieved from the server.
    /// </summary>
    internal static async Task<string> Add(HttpClient client, string token, string zoneName, string domainName, string recordType, int ttl, bool overwrite, string comments, string extraUrlParams)
    {
        if (zoneName.StartsWith("did:"))
            zoneName = Utils.ToDNS(zoneName);

        if (domainName.StartsWith("did:"))
            domainName = Utils.ToDNS(domainName);

        var requestUrl = $"/api/zones/records/add?" +
            $"token={token}" +
            $"&zone={zoneName}" +
            $"&domain={domainName}" +
            $"&type={recordType}" +
            $"&ttl={ttl}" +
            $"&overwrite={overwrite}" +
            $"&comments={comments}" +
            $"{extraUrlParams}"; // for record specific keys


        var req = await client.GetAsync(requestUrl);
        var res = await req.Content.ReadAsStringAsync();

        return Utils.FormatJson(res);
    }


    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#delete-record
    internal static async Task<string> Delete(HttpClient http, string token, string zoneName, string domainName, string recordType, string v)
    {
        throw new NotImplementedException();
    }


}




