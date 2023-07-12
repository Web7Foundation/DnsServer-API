
using System.ComponentModel;

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

    #endregion

    #region dns client

    #endregion

}
