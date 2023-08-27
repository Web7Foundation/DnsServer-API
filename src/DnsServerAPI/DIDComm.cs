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


    /// <summary>
    /// Generates a URI that can be used to send an update request.
    /// </summary>
    public string ToUpdateUri(VerificationMethodMap newVmm)
    {
        return this.ToUri() +
            "&new_vmm_id=" + Uri.EscapeDataString(newVmm.Id) +
            "&new_vmm_controller=" + Uri.EscapeDataString(newVmm.Controller) +
            "&new_vmm_type=" + Uri.EscapeDataString(newVmm.Type_) +
            "&new_vmm_comment=" + Uri.EscapeDataString(newVmm.Comment) +
            "&new_vmm_keyPublicJsonWebKey=" + Uri.EscapeDataString(newVmm.keyPublicJsonWebKey) +
            "&new_vmm_keyPublicJsonWebKeyString=" + Uri.EscapeDataString(newVmm.keyPublicJsonWebKeyString) +
            "&new_vmm_publicKeyMultibase=" + Uri.EscapeDataString(newVmm.publicKeyMultibase) +
            "&new_vmm_publicKeyJwk=" + Uri.EscapeDataString(newVmm.publicKeyJwk);
    }

    /// <summary>
    /// Generates a URI that can be used to send an add or delete request.
    /// </summary>
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


    public string ToUpdateUri(ServiceMap newSm)
    {
        return this.ToUri() +
            "&new_sm_id=" + Uri.EscapeDataString(newSm.Id) +
            "&new_sm_serviceEndpoint=" + Uri.EscapeDataString(newSm.ServiceEndpoint) +
            "&new_sm_type=" + Uri.EscapeDataString(newSm.Type_) +
            "&new_sm_comment=" + Uri.EscapeDataString(newSm.Comment);
    }

    public string ToUri()
    {
        return "&sm_id=" + Uri.EscapeDataString(Id) +
               "&sm_serviceEndpoint=" + Uri.EscapeDataString(ServiceEndpoint) +
               "&sm_type=" + Uri.EscapeDataString(Type_) +
               "&sm_comment=" + Uri.EscapeDataString(Comment);
    }
}
