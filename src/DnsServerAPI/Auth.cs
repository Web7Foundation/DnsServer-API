using Newtonsoft.Json.Linq;

namespace DnsServerAPI;

public class Auth
{

    public static async Task<string> GetLoginToken(string address, string username, string password)
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri(address)
        };

        var req = await client.GetAsync($"/api/user/login?user={username}&pass={password}&includeInfo=true");
        string res = await req.Content.ReadAsStringAsync();
        JObject.Parse(res).TryGetValue("token", out JToken jtoken);

        if (jtoken != null)
        {
            return jtoken.ToString();
        }
        else
        {
            throw new Exception("Failed to login to Dns Server. Invalid username and/or password.");
        }

    }
}
