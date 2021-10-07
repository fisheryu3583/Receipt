using Microsoft.VisualStudio.TestTools.UnitTesting;
using Receipt;

namespace ReceiptTests
{
    [TestClass]
    public class ShoppingBasketsTests
    {
        [TestMethod]
        public void AddProduct_WhenAddingAExemptedProduct_SalesTaxesShouldBeZero()
        {
            ShoppingBaskets shoppingBasket = new ShoppingBaskets();
            Product book = new Product("book", 12.49, false, false);

            shoppingBasket.AddProduct(book);

            double expected = 0.0;
            double actual = shoppingBasket.SalesTaxes;

            Assert.AreEqual(expected, actual, message: "The sales taxes were unexpectedly calculated for a book");
        }

        [TestMethod]
        public void AddProduct_WhenAddingABasicProduct_SalseTaxShouldBeCalculatedForBasicTax()
        {
            ShoppingBaskets shoppingBaskets = new ShoppingBaskets();
            Product musicCD = new Product("music CD", 14.99, true, false);

            shoppingBaskets.AddProduct(musicCD);

            double expected = 1.5;
            double actual = shoppingBaskets.SalesTaxes;

            Assert.AreEqual(expected, actual, message: "Incorrect calculation of sales tax for a basic product");
        }

        [TestMethod]
        public void AddProduct_WhenAddingAImportedProduct_SalseTaxShouldBeCalculatedForImportTax()
        {
            ShoppingBaskets shoppingBaskets = new ShoppingBaskets();
            Product importedChocolate = new Product("box of chocolate", 10.0, false, true);

            shoppingBaskets.AddProduct(importedChocolate);

            double expected = 0.5;
            double actual = shoppingBaskets.SalesTaxes;

            Assert.AreEqual(expected, actual, message: "Incorrect calculation of sales tax for a import product");
        }

        [TestMethod]
        public void AddProduct_WhenAddingAImportedBasicProduct_SalseTaxShouldBeCalculatedForBothOfBasicTaxAndImportTax()
        {
            ShoppingBaskets shoppingBaskets = new ShoppingBaskets();
            Product importedPerfume = new Product("bottle of perfume", 47.5, true, true);

            shoppingBaskets.AddProduct(importedPerfume);

            double expected = 7.15;
            double actual = shoppingBaskets.SalesTaxes;

            Assert.AreEqual(expected, actual, message: "Incorrect calculation of sales tax and import tax for a import basic product");
        }

        [TestMethod]
        public void AddProduct_WhenAddingAProductWithSalesTaxes_RoundingRuleShouldBeRoundedUpToNearestPointZeroFive()
        {
            ShoppingBaskets shoppingBaskets = new ShoppingBaskets();
            Product importedChocolate = new Product("imported box of chocolate", 11.25, false, true);

            shoppingBaskets.AddProduct(importedChocolate);

            double expected = 0.6;
            double actual = shoppingBaskets.SalesTaxes;

            Assert.AreEqual(expected, actual, message: "Incorrect rounded sales taxes");
        }
    }
}
