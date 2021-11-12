public class DeliveryInformation : BaseAddressInformation
{
    public int? Floor { get; set; }

    #nullable disable
    protected DeliveryInformation() {}
    #nullable enable

    public DeliveryInformation(string name, string address, int? floor) : base(name, address)
    {
        Floor = floor;
    }
}