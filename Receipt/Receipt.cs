using System;

namespace Receipt
{
    class Receipt
    {
        static void Main(string[] args)
        {
            PrintReceiptDetails(GetShoppingBaskets1());
            PrintReceiptDetails(GetShoppingBaskets2());
            PrintReceiptDetails(GetShoppingBaskets3());
        }

        private static void PrintReceiptDetails(ShoppingBaskets shoppingBaskets)
        {
            shoppingBaskets.Items.ForEach((item) =>
            {
                Console.WriteLine($"\t1 {(item.IsImport ? "imported" : "")} {item.Name}: {item.Total.ToString("N2")}");
            });
            Console.WriteLine($"\tSalse Taxes: {shoppingBaskets.SalesTaxes.ToString("N2")}");
            Console.WriteLine($"\tTotal: {shoppingBaskets.Total.ToString("N2")}\n");
        }

        private static ShoppingBaskets GetShoppingBaskets1()
        {
            ShoppingBaskets shoppingBaskets = new ShoppingBaskets();

            shoppingBaskets.AddProduct(new Product("book", 12.49, false, false));
            shoppingBaskets.AddProduct(new Product("music CD", 14.99, true, false));
            shoppingBaskets.AddProduct(new Product("chocolate bar", 0.85, false, false));

            return shoppingBaskets;
        }

        private static ShoppingBaskets GetShoppingBaskets2()
        {
            ShoppingBaskets shoppingBaskets = new ShoppingBaskets();

            shoppingBaskets.AddProduct(new Product("box of chocolates", 10.00, false, true));
            shoppingBaskets.AddProduct(new Product("bottle of perfume", 47.50, true, true));

            return shoppingBaskets;
        }

        private static ShoppingBaskets GetShoppingBaskets3()
        {
            ShoppingBaskets shoppingBaskets = new ShoppingBaskets();

            shoppingBaskets.AddProduct(new Product("bottle of perfume", 27.99, true, true));
            shoppingBaskets.AddProduct(new Product("bottle of perfume", 18.99, true, false));
            shoppingBaskets.AddProduct(new Product("packet of headache pills", 9.75, false, false));
            shoppingBaskets.AddProduct(new Product("box of chocolates", 11.25, false, true));

            return shoppingBaskets;
        }
    }
}
