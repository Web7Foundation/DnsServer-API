namespace DnsServerAPI.DIDComm;

public class VerificationMethodMap
{
    public string Id { get; set; }
    public string Comment { get; set; }
    public string Type_ { get; set; }
    public string Controller { get; set; }
    public string keyPublicJsonWebKey { get; set; }            // STRING (Json Text) Web7.TrustLibrary.Did.DIDDocumenter() - JsonWebKeyDotnet6
    public string keyPublicJsonWebKeyString { get; set; }      // STRING (Json Text)
    public string publicKeyMultibase { get; set; }             // STRING (Json Text)
    public string publicKeyJwk { get; set; }

    public string ToUri()
    {
        return "&vmm_controller=" + Uri.EscapeDataString(Controller) +
               "&vmm_type=" + Uri.EscapeDataString(Type_) +
               "&vmm_comment=" + Uri.EscapeDataString(Comment) +
               "&vmm_id=" + Uri.EscapeDataString(Id) +
               "&vmm_keyPublicJsonWebKey=" + Uri.EscapeDataString(keyPublicJsonWebKey) +
               "&vmm_keyPublicJsonWebKeyString=" + Uri.EscapeDataString(keyPublicJsonWebKeyString) +
               "&vmm_publicKeyMultibase=" + Uri.EscapeDataString(publicKeyMultibase) +
               "&vmm_publicKeyJwk=" + Uri.EscapeDataString(publicKeyJwk);
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
