using billingapi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace billingapi.Services
{
    public class BillingService
    {
        private readonly IMongoCollection<Billing> _billings;

        public BillingService(IBillingDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _billings = database.GetCollection<Billing>(settings.BillingsCollectionName);
        }

        public List<Billing> Get() =>
            _billings.Find(x => true).ToList();

        public Billing Get(string id) =>
            _billings.Find<Billing>(x => x.Id == id).FirstOrDefault();

        public Billing Create(Billing billing)
        {
            _billings.InsertOne(billing);
            return billing;
        }

        public void Update(string id, Billing billing) =>
            _billings.ReplaceOne(x => x.Id == id, billing);

        public void Remove(Billing billing) =>
            _billings.DeleteOne(x => x.Id == billing.Id);

        public void Remove(string id) =>
            _billings.DeleteOne(x => x.Id == id);
    }
}