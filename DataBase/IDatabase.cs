using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public interface IDatabase
    {
        void SaveData(Invoice invoice);
    }

    public class SaveInMongo : IDatabase
    {
        public void SaveData(Invoice invoice)
        {
            var connectionString = "mongodb+srv://sudharshan:sudharshan@mernauth.jsizlbe.mongodb.net/InvoiceDB?retryWrites=true&w=majority&appName=mernauth";
            var client = new MongoClient(connectionString);

            var database = client.GetDatabase("InvoiceDB");
            var collections = database.GetCollection<BsonDocument>("Invoices");

            var document = new BsonDocument
            {
                { "Marker Name", invoice.GetMarkerName() },
                { "Marker Color", invoice.GetMarkerColor() },
                { "Quantity", invoice.GetQuantity() },
                { "Item Price", invoice.GetItemPrice() },
                { "Total Price",invoice.GetPrice() },
                { "Invoice Generated On", DateTime.Now }
            };

            collections.InsertOne(document);

            Console.WriteLine("Data saved in MongoDB");
        }
    }
}
