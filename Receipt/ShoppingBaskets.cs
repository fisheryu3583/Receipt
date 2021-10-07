using System;
using System.Collections.Generic;

namespace Receipt
{
    public class ShoppingBaskets
    {
        private List<ShoppingBaseketsItem> _items { get; set; } = new List<ShoppingBaseketsItem>();

        private double _basicSalesTaxes
        {
            get
            {
                double basicSalesTaxes = 0.0;
                _items.ForEach((item) => basicSalesTaxes += item.BasicSalesTaxes);
                return basicSalesTaxes;
            }
        }
        private double _ImportTaxes
        {
            get
            {
                double importTaxes = 0.0;
                _items.ForEach((item) => importTaxes += item.ImportTaxes);
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

        public void AddProduct(Product product)
        {
            ShoppingBaseketsItem item = new ShoppingBaseketsItem(product);
            _items.Add(item);
        }
    }
}
