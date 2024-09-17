using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SolidPrinciples
{
    public interface IInvoice
    {
        void printInvoice(Invoice invoice);
    }

    public class PrintInvoiceTxt : IInvoice
    {
        public void printInvoice(Invoice invoice)
        {
            string filePath = $"D:\\Personal\\Solid Principles\\Invoices\\Invoice_{invoice.GetInvoiceDate():yyyyMMdd_HHmmss}.txt";
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine($"Marker Name: {invoice.GetMarkerName()}");
                writer.WriteLine($"Marker Color: {invoice.GetMarkerColor()}");
                writer.WriteLine($"Quantity: {invoice.GetQuantity()}");
                writer.WriteLine($"Item Price: {invoice.GetItemPrice()}");
                writer.WriteLine($"Total Price: {invoice.GetPrice()}");
                writer.WriteLine("Invoice generated on: " + invoice.GetInvoiceDate());
            }
            Console.WriteLine("Invoice text file created successfully.");
        }
    }

    public class PrintInvoicePdf : IInvoice
    {
        public void printInvoice(Invoice invoice)
        {
            string filePath = $"D:\\Personal\\Solid Principles\\Invoices\\Invoice_{invoice.GetInvoiceDate():yyyyMMdd_HHmmss}.pdf";

            // Create a Document object
            using (Document document = new Document(PageSize.A4))
            {
                // Create a PdfWriter instance
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                // Open the document for writing
                document.Open();

                // Add content to the document
                document.Add(new Paragraph($"Marker Name: {invoice.GetMarkerName()}"));
                document.Add(new Paragraph($"Marker Color: {invoice.GetMarkerColor()}"));
                document.Add(new Paragraph($"Quantity: {invoice.GetQuantity()}"));
                document.Add(new Paragraph($"Item Price: {invoice.GetPrice() / invoice.GetQuantity()}"));  // Assumes price per item is calculated this way
                document.Add(new Paragraph($"Total Price: {invoice.GetPrice()}"));
                document.Add(new Paragraph($"Invoice generated on: {invoice.GetInvoiceDate()}"));

                // Close the document
                document.Close();
            }

            Console.WriteLine("Invoice PDF created successfully.");
        }
    }
}
