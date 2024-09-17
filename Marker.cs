using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SolidPrinciples
{
    public class Marker
    {
        public String _Name;
        public String _Color;
        public double _Price;
        public Marker(string name, string color, double price)
        {
            this._Name = name;
            this._Color = color;
            this._Price = price;
        }
    }

    public class Invoice
    {
        private Marker marker;
        private int Quantity;

        public Invoice(Marker marker, int quantity)
        {
            this.marker = marker;
            this.Quantity = quantity;
        }

        public string GetMarkerName()
        {
            return this.marker._Name;
        }

        public string GetMarkerColor()
        {
            return this.marker._Color;
        }

        public double GetQuantity()
        {
            return this.Quantity;
        }

        public double GetItemPrice()
        {
            return this.marker._Price;
        }

        public double GetPrice()
        {
            return this.marker._Price*this.Quantity;
        }
        
        public DateTime GetInvoiceDate()
        {
            return DateTime.Now;
        }
    }
}
