using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.SauceDemo;

namespace SeleniumTest.SauceDemoTest
{
    public class ProductsTest
    {
        public static IWebDriver driver = new ChromeDriver();
        public ProductsPage productsPage = new ProductsPage(driver);

        [SetUp]
        public void Setup()
        {
            LoginPage loginpage = new LoginPage(driver);
            loginpage.Open();
            var login = "standard_user";
            var password = "secret_sauce";
            loginpage.Login(login, password);
        }

        [Test, Order(1)]
        public void AddToCart_VerifyIfAddToCartTrue()
        {
            productsPage.AddToCart();
            Assert.IsTrue(productsPage.IsElementPresent());
        }

        [Test, Order(2)]
        public void RemoveFromCart_VerifyIfRemoveFromCartTrue()
        {
            productsPage.AddToCart();
            productsPage.RemoveFromCart();
            Assert.IsFalse(productsPage.IsElementPresent());
        }
    }
}
