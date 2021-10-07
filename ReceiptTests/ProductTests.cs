using Microsoft.VisualStudio.TestTools.UnitTesting;
using Receipt;

namespace ReceiptTests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void Constructor_NewProduct_PropertyValuesAreExpected()
        {
            Product product = new Product("book", 12.49, true, false);

            bool isNameMatched = product.Name.Equals("book");
            bool isBasicMatched = product.IsBasic.Equals(true);
            bool isImportMatched = product.IsImport.Equals(false);
            bool arePropertyValuesMatched = isNameMatched && isBasicMatched && isImportMatched;

            Assert.IsTrue(arePropertyValuesMatched, "The property values of the product are unexpected after new");
        }
    }
}
