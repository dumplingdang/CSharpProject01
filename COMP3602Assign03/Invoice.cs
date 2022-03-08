using System;
using System.Collections.Generic;

namespace COMP3602Assign03
{
    class Invoice
    {
        private int invoiceNumber;
        private DateTime invoiceDate;
        private int discountPercentage;
        private int discountPeriod;
        private List<Item> itemList = new List<Item>();

        public Invoice(string invoiceNumber, string invoiceDate, string terms)
        {
            int.TryParse(invoiceNumber, out this.invoiceNumber);
            DateTime.TryParse(invoiceDate, out this.invoiceDate);
            discountPercentage = Convert.ToInt32(terms.Substring(0, 1));
            discountPeriod = Convert.ToInt32(terms.Substring(1, 2));
            DiscountDate = this.invoiceDate.AddDays(discountPeriod);
        }
        public int InvoiceNumber
        {
            get { return invoiceNumber; }
        }
        public void SetInvoiceNumber(string invoiceNumber)
        {
            int.TryParse(invoiceNumber, out this.invoiceNumber);
        }
        public DateTime InvoiceDate
        {
            get { return invoiceDate; }
        }
        public void SetInvoiceDate(string invoiceDate)
        {
            DateTime.TryParse(invoiceDate, out this.invoiceDate);
        }
        public int DiscountPeriod
        {
            get { return discountPeriod; }
        }
        public void SetDiscountPeriod(string terms)
        {
            discountPeriod = Convert.ToInt32(terms.Substring(1, 2));
        }
        public DateTime DiscountDate { get; set; }
        public int DiscountPercentage
        {
            get { return discountPercentage; }
        }
        public void SetDiscountPercentage(string terms)
        {
            discountPercentage = Convert.ToInt32(terms.Substring(0, 1));
        }
        public void AddItem(Item item)
        {
            itemList.Add(item);
        }
        public List<Item> ItemsList
        {
            get { return itemList; }
        }
        public decimal Subtotal
        {
            get
            {
                decimal subtotal = 0m;
                foreach (Item item in itemList)
                {
                    subtotal += item.ItemAmount;
                }
                return subtotal;
            }
        }
        public decimal GST { get { return Subtotal * 0.05m; } }
        public decimal PST
        {
            get
            {
                decimal pst = 0m;
                foreach (Item item in itemList)
                {
                    if (item.PstTaxable == "Y")
                    {
                        pst += item.ItemAmount * 0.07m;
                    }
                }
                return pst;
            }
        }
        public decimal TotalAmount { get { return Subtotal + GST + PST; } }
        public decimal TotalDiscount { get { return TotalAmount * discountPercentage * 0.01m; } }
        public override string ToString()
        {
            return $"Invoice Number: {InvoiceNumber}; Invoice Date: {InvoiceDate}; Discount Percentage: {DiscountPercentage}; Discount Period: {discountPeriod}";
        }
    }
}
