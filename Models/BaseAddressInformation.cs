public abstract class BaseAddressInformation
{
    public string Name { get; set; }
    public string Address { get; set; }

    #nullable disable
    protected BaseAddressInformation() {}
    #nullable enable

    public BaseAddressInformation(string name, string address)
    {
        Name = name;
        Address = address;
    }
}