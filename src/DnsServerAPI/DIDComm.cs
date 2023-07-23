namespace DnsServerAPI.DIDComm;

public class JSONKeyMap
{
    public string crv { get; set; } = "";

    public string e { get; set; } = "";

    public string n { get; set; } = "";

    public string x { get; set; } = "";

    public string y { get; set; } = "";

    public string kty { get; set; } = "";

    public string kid { get; set; } = "";
}

public class VerificationMethodMap
{
    public string Id { get; set; } = "";

    public string Comment { get; set; } = "";

    public string Type_ { get; set; } = "";

    public string Controller { get; set; } = "";

    public string PublicKeyMultibase { get; set; } = "";

    public JSONKeyMap PublicKeyJwk { get; set; } = new();

    public string PublicKeyBase58 { get; set; } = "";

    public string PrivateKeyBase58 { get; set; } = "";

    public string ToUri()
    {
        return "&vmm_controller=" + Uri.EscapeDataString(Controller) +
               "&vmm_type=" + Uri.EscapeDataString(Type_) +
               "&vmm_comment=" + Uri.EscapeDataString(Comment) +
               "&vmm_id=" + Uri.EscapeDataString(Id) +
               "&vmm_publicKeyMultibase=" + Uri.EscapeDataString(PublicKeyMultibase) +
               "&vmm_publicKeyBase58=" + Uri.EscapeDataString(PublicKeyBase58) +
               "&vmm_privateKeyBase58=" + Uri.EscapeDataString(PrivateKeyBase58) +
               "&vmm_jwk_crv=" + Uri.EscapeDataString(PublicKeyJwk.crv) +
               "&vmm_jwk_e=" + Uri.EscapeDataString(PublicKeyJwk.e) +
               "&vmm_jwk_n=" + Uri.EscapeDataString(PublicKeyJwk.n) +
               "&vmm_jwk_x=" + Uri.EscapeDataString(PublicKeyJwk.x) +
               "&vmm_jwk_y=" + Uri.EscapeDataString(PublicKeyJwk.y) +
               "&vmm_jwk_kty=" + Uri.EscapeDataString(PublicKeyJwk.kty) +
               "&vmm_jwk_kid=" + Uri.EscapeDataString(PublicKeyJwk.kid);
    }
}

public class ServiceMap
{
    public string Id { get; set; }

    public string Comment { get; set; }

    public string Type_ { get; set; }

    public string ServiceEndpoint { get; set; }

    public string ToUri()
    {
        return "&sm_id=" + Uri.EscapeDataString(Id) +
               "&sm_serviceEndpoint=" + Uri.EscapeDataString(ServiceEndpoint) +
               "&sm_type=" + Uri.EscapeDataString(Type_) +
               "&sm_comment=" + Uri.EscapeDataString(Comment);
    }
}
