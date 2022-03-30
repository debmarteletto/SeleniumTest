using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.SauceDemo;

namespace SeleniumTest.SauceDemoTest
{
    public class LoginTest
    {
        public static IWebDriver driver = new ChromeDriver();
        public LoginPage loginpage = new LoginPage(driver);

        [SetUp]
        public void Setup()
        {
            loginpage.Open();
        }

        [Test, Order(1)]
        public void IsUserNameIsDisplayed_VerifyIfUsernameIsTrueDisplayed()
        {
            Assert.That(loginpage.UserNameIsDisplayed, Is.True);
        }

        [Test, Order(2)]
        public void IsPasswordIsDisplayed_VerifyIfPasswordIsTrueDisplayed()
        {
            Assert.That(loginpage.PasswordIsDisplayed, Is.True);
        }

        [Test, Order(3)]
        public void LoginButttonIsDisplayed_VerifyIfLoginButttonIsDisplayed()
        {
            Assert.That(loginpage.LoginButttonIsDisplayed, Is.True);
        }

        [Test, Order(4)]
        public void Login_VerifyLoginOperation()
        {            
            var login = "standard_user";
            var password = "secret_sauce";
            loginpage.Login(login, password);
            Assert.AreEqual("https://www.saucedemo.com/inventory.html", driver.Url);
        }

        [Test, Order(5)]
        public void MenuIsDisplayed_VerifyIfMenuIsDisplayed()
        {
            var login = "standard_user";
            var password = "secret_sauce";
            loginpage.Login(login, password);
            Assert.That(loginpage.MenuIsDisplayed, Is.True);
        }

        [Test, Order(6)]
        public void LogoutIsDisplayed_VerifyIfLogoutIsDisplayed()
        {
            var login = "standard_user";
            var password = "secret_sauce";
            loginpage.Login(login, password); 
            Assert.That(loginpage.LogoutIsDisplayed, Is.True);
        }

        [Test, Order(7)]
        public void Logout_VerifyLoginOperation()
        {
            var login = "standard_user";
            var password = "secret_sauce";
            loginpage.Login(login, password);
            loginpage.Logout();
            Assert.AreEqual("https://www.saucedemo.com/", driver.Url);
        }

        [Test, Order(8)]
        public void Logout_VerifyLoginOperationIfUsernameIsRequired()
        {
            var login = "";
            var password = "";
            loginpage.Login(login, password);
            Assert.That(loginpage.CheckIfUsernameIsRequired, Is.True);
        }


        [Test, Order(9)]
        public void Logout_VerifyLoginOperationIfUsernameAndPasswordExist()
        {
            var login = "debora";
            var password = "12345";
            loginpage.Login(login, password);
            Assert.That(loginpage.CheckIfUsernameAndPasswordExist, Is.True);
        }
    }
}