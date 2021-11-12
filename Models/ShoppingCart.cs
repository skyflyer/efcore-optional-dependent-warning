public class ShoppingCart
{
    public int Id { get; set; }
    public string Salesperson { get; private set; }

    public BillingInformation? BillingInformation { get; private set; }
    public DeliveryInformation? DeliveryInformation { get; private set; }

#nullable disable
    protected ShoppingCart() { }
#nullable enable

    public ShoppingCart(string salesperson)
    {
        Salesperson = salesperson;
    }

    public void SetBilling(BillingInformation billingInformation)
    {
        BillingInformation = billingInformation;
    }

    public void SetDelivery(DeliveryInformation deliveryInformation)
    {
        DeliveryInformation = deliveryInformation;
    }
}
