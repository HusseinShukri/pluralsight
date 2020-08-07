namespace PriceCalculator.PriceCalculator.Products
{
    public class Product
    {
        public Product() { }
        public Product(string name, int uPCCode, double price)
        {
            Name = name;
            UPCCode = uPCCode;
            Price = price;
        }
        public string Name { get; set; }
        public int UPCCode { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"Name : {this.Name} UPC code :  {this.UPCCode }  price : {this.Price}";
        }
    }
}
