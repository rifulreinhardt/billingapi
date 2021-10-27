namespace billingapi.Models
{
    public class BillingDbSettings : IBillingDbSettings
    {
        public string BillingsCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }

    public interface IBillingDbSettings
    {
        string BillingsCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
