namespace Receipt
{
    public class Product
    {
        public Product(string name, double price, bool isBasic, bool isImport)
        {
            Name = name;
            Price = price;
            IsBasic = isBasic;
            IsImport = isImport;
        }

        public string Name { get; }
        public double Price { get; }
        public bool IsBasic { get; }
        public bool IsImport { get; }
    }
}
