using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumTest.SauceDemo
{
    public class LoginPage : BaseWebPage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public LoginPage Open()
        {
            Driver.Navigate().GoToUrl(BaseUrl);
            return this;
        }

        private IWebElement txtUsername => Driver.FindElement(By.Name("user-name"));
        private IWebElement txtpassword => Driver.FindElement(By.Name("password"));
        private IWebElement btnLogin => Driver.FindElement(By.XPath("//input[@value='Login']"));
        private IWebElement buttonMenu => Driver.FindElement(By.Id("react-burger-menu-btn"));
        private IWebElement linkLogout => Driver.FindElement(By.Id("logout_sidebar_link"));

        public void Login(string userName, string password)
        {
            txtUsername.SendKeys(userName);
            txtpassword.SendKeys(password);
            btnLogin.Submit();
        }

        public void Logout()
        {
            buttonMenu.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            linkLogout.Click();
        }

        public bool UserNameIsDisplayed()
        {
            return txtUsername.Displayed;
        }      

        public bool PasswordIsDisplayed()
        {
            return txtpassword.Displayed;
        }

        public bool LoginButttonIsDisplayed()
        {
            return btnLogin.Displayed;
        }

        public bool MenuIsDisplayed()
        {
            buttonMenu.Click();
            return buttonMenu.Displayed;
        }

        public bool LogoutIsDisplayed()
        {
            buttonMenu.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            return linkLogout.Displayed;
        }

        public bool CheckIfUsernameIsRequired()
        {
            try
            {
                Driver.FindElement(By.XPath("//h3[contains (text(),'Epic sadface: Username is required')]"));               
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool CheckIfUsernameAndPasswordExist()
        {
            try
            {
                Driver.FindElement(By.XPath("//h3[contains (text(),'Epic sadface: Username and password do not match any user in this service')]"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }   
}
