using static System.Net.WebRequestMethods;

namespace DnsServerAPI;

public enum Protocol
{
    Udp, 
    Tcp,
    Tls,
    Https,
    Quic
}

public static class DnsClient
{
    // TODO: Implement DNS Client 

    // https://github.com/TechnitiumSoftware/DnsServer/blob/master/APIDOCS.md#dns-client-api-calls
    public static async Task<string> ResolveToJson(HttpClient http, string token, string domain, string type, string server, Protocol protocol)
    {
        if (domain.StartsWith("did:"))
            domain = Utils.ToDNS(domain);

        string requestUrl = $"/api/dnsClient/resolve?" +
            $"token={token}" +
            $"&server={server}" +
            $"&domain={domain}" +
            $"&type={type}" +
            $"&protocol={protocol}";

        var req = await http.GetAsync(requestUrl);
        var res = await req.Content.ReadAsStringAsync();

        return Utils.FormatJson(res);
    }
}
