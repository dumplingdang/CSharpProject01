using System;
using System.Collections.Generic;
using System.IO;
namespace COMP3602Assign03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "COMP3602 - Assignment 3 - Invoice Parser - A01199436";

            StreamReader streamReader = null;
            string path = @"..\..\InvoiceData.txt";
            string lineData;
            string[] invoiceStructure;
            List<Invoice> invoices = new List<Invoice>(1000000);

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
            }
            else
            {
                try
                {
                    using (streamReader = new StreamReader(path))
                    {
                        while ((lineData = streamReader.ReadLine()) != null)
                        {
                            //split a line to "header | line item 1 | line item 2 | ..."
                            invoiceStructure = lineData.Split('|');

                            //split the 1st part of structure to invoice header elements "invoice number : invoice date : terms"
                            string[] invoiceHeaderElements = invoiceStructure[0].Split(':');

                            //generate an invoice object with header elements and add the object to the invoice list
                            Invoice invoice = new Invoice(invoiceHeaderElements[0], invoiceHeaderElements[1], invoiceHeaderElements[2]);
                            invoices.Add(invoice);

                            for (int i = 1; i < invoiceStructure.Length; i++)
                            {
                                //split the rest parts of invoice structure to multiple item elements: "quantity : sku : description : price : pstTaxable"
                                string[] itemElements = invoiceStructure[i].Split(':');

                                //generate an invoice item object and add the object to an invoice generated above
                                Item item = new Item(itemElements[0], itemElements[1], itemElements[2], itemElements[3], itemElements[4]);
                                invoice.AddItem(item);
                            }
                        }
                        ConsolePrinter.PrintInvoiceList(invoices);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
                finally
                {
                    streamReader.Close();
                }
            }
        }
    }
}
