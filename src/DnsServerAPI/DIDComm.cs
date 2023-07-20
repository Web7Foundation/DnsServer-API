using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnsServerAPI.DIDComm;

public class JSONKeyMap
{
    public string crv;

    public string e;

    public string n;

    public string x;

    public string y;

    public string kty;

    public string kid;
}

public class VerificationMethodMap
{
    public string Id { get; set; }

    public string Comment { get; set; }

    public string Type_ { get; set; }

    public string Controller { get; set; }

    public string PublicKeyMultibase { get; set; }

    public JSONKeyMap PublicKeyJwk { get; set; }

    public string PublicKeyBase58 { get; set; }

    public string PrivateKeyBase58 { get; set; }

    public string AsApiUrl()
    {
        string url = "&vmm_controller=" + Controller +
               "&vmm_type=" + Type_ +
               "&vmm_comment=" + Comment +
               "&vmm_id=" + Id +
               "&vmm_publicKeyMultibase=" + PublicKeyMultibase +
               "&vmm_publicKeyBase58=" + PublicKeyBase58 +
               "&vmm_privateKeyBase58=" + PrivateKeyBase58 +
               "&vmm_jwk_crv=" + PublicKeyJwk.crv +
               "&vmm_jwk_e=" + PublicKeyJwk.e +
               "&vmm_jwk_n=" + PublicKeyJwk.n +
               "&vmm_jwk_x=" + PublicKeyJwk.x +
               "&vmm_jwk_y=" + PublicKeyJwk.y +
               "&vmm_jwk_kty=" + PublicKeyJwk.kty +
               "&vmm_jwk_kid=" + PublicKeyJwk.kid;

        return url;
    }
}

public class ServiceMap : TechnitiumLibrary.Net.Dns.ResourceRecords.ServiceMap 
{
    public string Id { get; set; }

    public string Comment { get; set; }

    public string Type_ { get; set; }

    public string ServiceEndpoint { get; set; }
}
