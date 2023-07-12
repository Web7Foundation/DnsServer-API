using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnsServerAPI;

public static class Utils
{
    // indents a json string
    public static string FormatJson(string json)
    {
        dynamic parsedJson = JsonConvert.DeserializeObject(json);
        return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
    }

    /// <summary>
    /// Converts from DNS to DID notation. Ex. "example.did" to "did:example"
    /// </summary>
    public static string ToDID(string input)
    {
        string ret = "";
        string[] parts = input.Split('.');

        if (parts.Length == 0) return input;

        for (int i = parts.Length; i >= 1; i--)
        {
            ret += parts[i-1];

            if (i != 1)
            {
                ret += ":";
            }
        }

        return ret;
    }

    /// <summary>
    /// Converts from DID to DNS notation. Ex. "did:example" to "example.did"
    /// </summary>
    public static string ToDNS(string input)
    {
        string ret = "";
        string[] parts = input.Split(':');

        if (parts.Length == 0) return input;

        for (int i = parts.Length; i >= 1; i--)
        {
            ret += parts[i - 1];

            if (i != 1)
            {
                ret += ".";
            }
        }

        return ret;
    }

}
