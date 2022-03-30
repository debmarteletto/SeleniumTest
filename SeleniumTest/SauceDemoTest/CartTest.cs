using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.SauceDemo;

namespace SeleniumTest.SauceDemoTest
{
    public class CartTest
    {
        public static IWebDriver driver = new ChromeDriver();
        public CartPage cartPage = new CartPage(driver);

        [SetUp]
        public void Setup()
        {
            LoginPage loginpage = new LoginPage(driver);
            loginpage.Open();
            var login = "standard_user";
            var password = "secret_sauce";
            loginpage.Login(login, password);
            ProductsPage productsPage = new ProductsPage(driver);
            productsPage.AddToCart();
            cartPage.Open();
        }

        [Test, Order(1)]
        public void RemoveFromCart_VerifyIfRemoveFromCart()
        {            
            cartPage.RemoveFromCart();
            Assert.IsFalse(cartPage.IsAnyElementPresent());
        }
    }   

}
