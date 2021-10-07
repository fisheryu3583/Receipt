using System;
using System.Collections.Generic;

namespace Receipt
{
    public class ShoppingBaskets
    {
        private double _basicSalesTaxes
        {
            get
            {
                double basicSalesTaxes = 0.0;
                Items.ForEach((item) => basicSalesTaxes += item.BasicSalesTaxes);
                return basicSalesTaxes;
            }
        }
        private double _ImportTaxes
        {
            get
            {
                double importTaxes = 0.0;
                Items.ForEach((item) => importTaxes += item.ImportTaxes);
                return importTaxes;
            }
        }

        public double SalesTaxes
        {
            get
            {
                return _basicSalesTaxes + _ImportTaxes;
            }
        }

        public double Total
        {
            get
            {
                double total = 0.0;
                Items.ForEach((item) => total += item.Total);
                return total;
            }
        }

        public List<ShoppingBaseketsItem> Items { get; set; } = new List<ShoppingBaseketsItem>();

        public void AddProduct(Product product)
        {
            ShoppingBaseketsItem item = new ShoppingBaseketsItem(product);
            Items.Add(item);
        }
    }
}
