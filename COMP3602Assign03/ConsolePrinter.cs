using System;
using System.Collections.Generic;

namespace COMP3602Assign03
{
    class ConsolePrinter
    {
        public static void PrintInvoiceList(List<Invoice> invoices)
        {
            string seperateLine = new string('-', 63);
            string dateFormat = "MMM dd, yyyy";

            Console.WriteLine("Invoice Listing");
            Console.WriteLine(seperateLine);

            foreach (Invoice invoice in invoices)
            {
                Console.WriteLine($"\n\n{"Invoice Number:",-16} {invoice.InvoiceNumber,-8}");
                Console.WriteLine($"{"Invoice Date:",-16} {invoice.InvoiceDate.ToString(dateFormat),-12}");
                Console.WriteLine($"{"Discount Date:",-16} {invoice.DiscountDate.ToString(dateFormat),-12}");
                Console.WriteLine($"{"Terms:",-16} {invoice.DiscountPercentage,4:N2}% {invoice.DiscountPeriod} days ADI");
                Console.WriteLine(seperateLine);
                Console.WriteLine($"{"Qty",-3} {"SKU",-12} {"Description",-20} {"Price",10:N2} {"PST",3} {"EXT",10}");
                Console.WriteLine(seperateLine);
                foreach (Item item in invoice.ItemsList)
                {
                    Console.WriteLine($"{item.Quantity,3} {item.SKU,-12} {item.Description,-20} {item.Price,10:N2} {item.PstTaxable,2}  {item.ItemAmount,10:N2}");
                }
                Console.WriteLine(seperateLine);
                Console.WriteLine($"{" ",16} {"Subtotal:",-35} {invoice.Subtotal,10:N2}");
                Console.WriteLine($"{" ",16} {"GST:",-35} {invoice.GST,10:N2}");
                if (invoice.PST > 0)
                {
                    Console.WriteLine($"{" ",16} {"PST:",-35} {invoice.PST,10:N2}");
                }
                Console.WriteLine(seperateLine);
                Console.WriteLine($"{" ",16} {"Total:",-35} {invoice.TotalAmount,10:N2}");
                Console.WriteLine($"\n{" ",16} {"Discount:",-35} {invoice.TotalDiscount,10:N2}");
            }
        }
    }
}
