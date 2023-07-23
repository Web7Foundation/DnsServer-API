namespace DnsServerAPI;

public class Api
{
    private string _token;
    private string _address;

    private readonly HttpClient _http;

    /// <summary>
    /// Constructor for the API class. A token can be acquired using Auth.GetLoginToken().
    /// </summary>
    public Api(string token, string address = "http://localhost:5380")
    {
        _address = address;
        _token = token;

        _http = new HttpClient()
        {
            BaseAddress = new Uri(_address)
        };
    }

    #region zone

    /// <summary>
    /// Returns a string List of all zones in the server.
    /// </summary>
    public async Task<List<string>> ListZones()
    {
        return await Zone.List(_http, _token);
    }

    /// <summary>
    /// Returns a string List of all records in the zone.
    /// </summary>
    public async Task<List<string>> ListZoneRecords(string zone)
    {
        return await Zone.ListZoneRecords(_http, _token, zone);
    }

    /// <summary>
    /// Add a zone. Returns 'true' if successful.
    /// </summary>
    public async Task<bool> AddZone(string zone)
    {
        return await Zone.Add(_http, _token, zone);
    }

    /// <summary>
    /// Delete a zone. Returns 'true' if successful.
    /// </summary>
    public async Task<bool> DeleteZone(string zone)
    {
        return await Zone.Delete(_http, _token, zone);
    }

    #endregion

    #region record

    /// <summary>
    /// Adds a record to a zone. Returns the JSON response from the server.
    /// Example usage for CNAME record in 'urlParams' parameter: "&cname=example.com"
    /// Example usage for TEXT record in 'urlParams' parameter: "&text=foo"
    /// See
    /// <a href="https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#add-record">APIDOCS.md#add-record</a>
    /// to see a list of url parameters.
    /// </summary>
    public async Task<string> AddRecord(string zone, string domain, string type, int ttl, bool overwrite, string? comments, string? urlParams)
    {
        return await Record.Add(_http, _token, zone, domain, type, ttl, overwrite, comments ?? "", urlParams ?? "");
    }

    /// <summary>
    /// Deletes a record to a zone. Returns the JSON response from the server.
    /// Example usage for CNAME record in 'urlParams' parameter: "&cname=example.com"
    /// Example usage for TEXT record in 'urlParams' parameter: "&text=foo"
    /// See
    /// <a href="https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#delete-record">APIDOCS.md#add-record</a>
    /// to see a list of url parameters.
    /// </summary>
    public async Task<string> DeleteRecord(string zone, string domain, string type, string urlParams)
    {
        return await Record.Delete(_http, _token, zone, domain, type, urlParams);
    }

    #endregion

    #region dns client

    public async Task<string> DnsClientResolveToJson(string domain, string type = "ANY", string server = "this-server", Protocol protocol = Protocol.Udp)
    {
        return await DnsClient.ResolveToJson(_http, _token, domain, type, server, protocol);
    }

    #endregion

}
