public class BillingInformation : BaseAddressInformation
{
    #nullable disable
    protected BillingInformation() {}
    #nullable enable

    public BillingInformation(string name, string address) : base(name, address)
    {
    }
}