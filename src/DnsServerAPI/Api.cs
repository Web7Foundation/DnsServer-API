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
    public async Task<List<string>> ListZoneRecords(string zoneName)
    {
        return await Zone.ListZoneRecords(_http, _token, zoneName);
    }

    /// <summary>
    /// Add a zone. Returns 'true' if successful.
    /// </summary>
    public async Task<bool> AddZone(string zoneName)
    {
        return await Zone.Add(_http, _token, zoneName);
    }

    /// <summary>
    /// Delete a zone. Returns 'true' if successful.
    /// </summary>
    public async Task<bool> DeleteZone(string zoneName)
    {
        return await Zone.Delete(_http, _token, zoneName);
    }

    #endregion

    #region record

    /// <summary>
    /// Adds a record to the specified zone. Returns the JSON response from the server.
    /// Example usage for CNAME record in 'extralUrlParams' parameter: "&cname=example.com"
    /// Example usage for TEXT record in 'extralUrlParams' parameter: "&text=foo"
    /// 
    /// See
    /// <a href="https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#add-record">APIDOCS.md#add-record</a>
    /// to see a list of url parameters.
    /// </summary>
    public async Task<string> AddRecord(string zoneName, string domainName, string recordType, int ttl, bool overwrite, string? comments, string? extralUrlParams)
    {
        return await Record.Add(_http, _token, zoneName, domainName, recordType, ttl, overwrite, comments ?? "", extralUrlParams ?? "");
    }

    public async Task<string> DeleteRecord(string zoneName, string domainName, string recordType, string? extralUrlParams)
    {
        return await Record.Delete(_http, _token, zoneName, domainName, recordType, extralUrlParams ?? "");
    }

    #endregion

    #region dns client

    #endregion

}
