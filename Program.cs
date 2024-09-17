﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class Program
    {
       public enum InvoiceTypeData
        {
            text,
            pdf,
        }
        static void Main(string[] args)
        {
            while (true)
            {
                //entering the values
                Console.Write("Please enter the marker name: ");
                String MarkerName = Console.ReadLine();
                Console.Write("Please enter the marker Color: ");
                String MarkerColor = Console.ReadLine();
                Console.Write("Please enter the marker Price: ");
                double MarkerPrice = Convert.ToDouble(Console.ReadLine());
                Console.Write("Please enter the Marker Quantity: ");
                int MarkerQuantity = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter the Invoice Type: ");
                String invoiceTypeInput = Console.ReadLine();
                // Initialising Marker and Invoice.
                Marker marker = new Marker(MarkerName, MarkerColor, MarkerPrice);
                Invoice invoice = new Invoice(marker, MarkerQuantity);

                if (Enum.TryParse(invoiceTypeInput, true, out InvoiceTypeData invoiceType))
                {
                    if (invoiceType == InvoiceTypeData.text)
                    {
                        PrintInvoiceTxt printInvoiceTxt = new PrintInvoiceTxt();
                        printInvoiceTxt.printInvoice(invoice);
                    }
                    else if (invoiceType == InvoiceTypeData.pdf)
                    {
                        PrintInvoicePdf printInvoicePdf = new PrintInvoicePdf();
                        printInvoicePdf.printInvoice(invoice);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid invoice type entered.");
                }

                SaveInMongo saveInMongo = new SaveInMongo();
                saveInMongo.SaveData(invoice); 
                //testing

                Console.ReadLine();
            }
        }
    }
}
