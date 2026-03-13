namespace OnlineStoreProject.Patterns
{
    public interface PricingStrategy
    {
        decimal CalculateTotal(decimal initialTotal);
    }

    public class NoDiscountStrategy : PricingStrategy
    {
        public decimal CalculateTotal(decimal initialTotal) => initialTotal;
    }

    public class PercentageDiscountStrategy : PricingStrategy
    {
        private readonly decimal _percentage;
        public PercentageDiscountStrategy(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal CalculateTotal(decimal initialTotal)
        {
            return initialTotal - (initialTotal * _percentage / 100);
        }
    }
}