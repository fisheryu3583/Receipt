using System;
namespace Receipt
{
    public class ShoppingBaseketsItem : Product
    {
        static readonly double RateOfBasicTax = 0.1;
        static readonly double RateOfImportTax = 0.05;

        public ShoppingBaseketsItem(Product product)
            : base(product.Name, product.Price, product.IsBasic, product.IsImport)
        {
            BasicSalesTaxes = GetBasicSalesTaxes(product);
            ImportTaxes = GetImportTaxes(product);
        }

        public double BasicSalesTaxes { get; }
        public double ImportTaxes { get; }

        public double Total
        {
            get
            {
                return Price + BasicSalesTaxes + ImportTaxes;
            }
        }

        private double GetBasicSalesTaxes(Product product)
        {
            if (!product.IsBasic) return 0.0;

            return GetRoundedUpToNearestPointZeroFive(product.Price * RateOfBasicTax);
        }

        private double GetImportTaxes(Product product)
        {
            if (!product.IsImport) return 0.0;

            return GetRoundedUpToNearestPointZeroFive(product.Price * RateOfImportTax);
        }

        private double GetRoundedUpToNearestPointZeroFive(double tax)
        {
            return Math.Ceiling(tax * 20.0) / 20.0;
        }
    }
}
