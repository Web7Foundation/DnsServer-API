namespace DnsServerAPI;

public class Api
{
    private string _token;
    private string _addr;

    private readonly HttpClient _http;

    /// <summary>
    /// Constructor for the API class. A token can be aquired using Auth.GetLoginToken().
    /// </summary>
    public Api(string address, string token)
    {
        _addr = address;
        _token = token;

        _http = new HttpClient()
        {
            BaseAddress = new Uri(_addr)
        };
    }

    #region zone

    public async Task<List<string>> ListZones()
    {
        return await Zone.List(_http, _token);
    }

    public async Task<List<string>> ListZoneRecords(string zoneName)
    {
        return await Zone.ListZoneRecords(_http, _token, zoneName);
    }

    /// <summary>
    /// Returns 'true' if successful.
    /// </summary>
    public async Task<bool> AddZone(string zoneName)
    {
        return await Zone.Add(_http, _token, zoneName);
    }

    /// <summary>
    /// Returns 'true' if successful.
    /// </summary>
    public async Task<bool> DeleteZone(string zoneName)
    {
        return await Zone.Delete(_http, _token, zoneName);
    }

    #endregion

    #region record

    /// <summary>
    /// Adds a record to the specified zone. Returns the json response from the server.
    /// Example usage for CNAME record in 'extralUrlParams' parameter: "&cname=example.com"
    /// Example usage for TEXT record in 'extralUrlParams' parameter: "&text=foo"
    /// 
    /// See
    /// <a href="https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#add-record">APIDOCS.md#add-record</a>
    /// to see a list of url parameters.
    /// </summary>
    public async Task<string> AddRecord(string zoneName, string recordType, int ttl, bool overwrite, string comments, string extralUrlParams)
    {
        return await Record.Add(_http, _token, zoneName, recordType, ttl, overwrite, comments, extralUrlParams);
    }

    #endregion

    #region dns client

    #endregion

}
