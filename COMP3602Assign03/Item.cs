namespace COMP3602Assign03
{
    class Item
    {
        private int quantity;
        private decimal price;

        public Item(string quantity, string sku, string description, string price, string pstTaxable)
        {
            int.TryParse(quantity, out this.quantity);
            SKU = sku;
            Description = description;
            decimal.TryParse(price, out this.price);
            PstTaxable = pstTaxable;
        }
        public int Quantity
        {
            get { return quantity; }
        }
        public void SetQuantity(string quantity)
        {
            int.TryParse(quantity, out this.quantity);
        }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Price
        {
            get { return price; }
        }
        public void SetPrice(string price)
        {
            decimal.TryParse(price, out this.price);
        }
        public string PstTaxable { get; set; }
        public decimal ItemAmount { get { return price * quantity; } }
        public override string ToString()
        {
            return $"Item: {Quantity}; SKU: {SKU}; Description: {Description}; Price: {Price}; PST Taxable: {PstTaxable}";
        }
    }
}
