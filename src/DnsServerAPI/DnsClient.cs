
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
    public static async Task<string> ResolveQuery(string token, string server, string domain, Protocol protocol = Protocol.Udp)
    {
        throw new NotImplementedException();
    }
}
