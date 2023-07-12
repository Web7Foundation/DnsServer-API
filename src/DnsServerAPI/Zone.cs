using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DnsServerAPI;

public static class Zone
{

    #region list, add, delete

    public static async Task<List<string>> List(HttpClient client, string token)
    {
        List<string> list = new List<string>();

        var req = await client.GetAsync($"/api/zones/list?token={token}&pageNumber=1&zonesPerPage=100");
        var res = await req.Content.ReadAsStringAsync();

        JObject jobj = JObject.Parse(res);
        int totalZones = int.Parse(jobj["response"]["totalZones"].ToString());

        for (int i = 0; i < totalZones; i++)
        {
            var name = jobj["response"]["zones"][i]["name"].ToString();
            list.Add(name);
        }

        return list;
    }

    public static async Task<bool> Add(HttpClient client, string token, string zoneName)
    {        
        var req = await client.GetAsync($"/api/zones/create?token={token}&zone={zoneName}&type=Primary");
        var res = await req.Content.ReadAsStringAsync();

        bool success = JObject.Parse(res)["status"].ToString() == "ok";
        return success;
    }
        

    public static async Task<bool> Delete(HttpClient client, string token, string zoneName)
    {
        var req = await client.GetAsync($"/api/zones/delete?token={token}&zone={zoneName}");
        var res = await req.Content.ReadAsStringAsync();

        bool success = JObject.Parse(res)["status"].ToString() == "ok";
        return success;
    }

    #endregion

    public static async Task<bool> IsValidZone(HttpClient client, string token, string zoneName)
    {
        var req = await client.GetAsync($"/api/zones/records/get?token={token}&domain={zoneName}&zone={zoneName}&listZone=true");
        var res = await req.Content.ReadAsStringAsync();

        if (JObject.Parse(res)["status"].ToString() == "error")
            return false;
        else
            return true;
    }

    public static async Task<List<string>> ListZoneRecords(HttpClient client, string token, string zoneName)
    {
        // get records
        var req = await client.GetAsync($"/api/zones/records/get?token={token}&domain={zoneName}&zone={zoneName}&listZone=true");
        var res = await req.Content.ReadAsStringAsync();
        
        // parse records
        JObject jobj = JObject.Parse(res);
        int totalRecords = int.Parse(jobj["response"]["totalRecords"].ToString());

        List<string> records = new List<string>();
        for (int i = 0; i < totalRecords; i++)
        {
            var record = jobj["response"]["records"][i]["name"].ToString();
            records.Add(record);
        }
        return records;
    }
}
