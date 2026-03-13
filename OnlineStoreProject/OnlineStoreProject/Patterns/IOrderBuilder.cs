namespace OnlineStoreProject.Patterns
{
    public interface IOrderBuilder
    {
        IOrderBuilder SetCustomer(string name);
        IOrderBuilder SetAddress(string address);

        IOrderBuilder SetPricingStrategy(PricingStrategy strategy);

        IOrderBuilder AddItemsFromCart(IIterator<OnlineStoreProject.Core.CartItem> cartIterator);
        OnlineStoreProject.Core.Order Build();
    }
}