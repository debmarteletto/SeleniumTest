using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumTest.SauceDemo
{
    public class ProductsPage : BaseWebPage
    {
        private readonly string _pageUrl;
        public ProductsPage(IWebDriver driver) : base(driver)
        {
            _pageUrl = "inventory.html";
        }
        public ProductsPage Open()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/{_pageUrl}");
            return this;
        }

        public void AddToCart()
        {
            List<IWebElement> elementList = new List<IWebElement>();
            elementList.AddRange(Driver.FindElements(By.Id("add-to-cart-sauce-labs-backpack")));
            elementList.AddRange(Driver.FindElements(By.Id("add-to-cart-sauce-labs-bolt-t-shirt")));
            elementList.AddRange(Driver.FindElements(By.Id("add-to-cart-sauce-labs-onesie")));
            elementList.AddRange(Driver.FindElements(By.Id("add-to-cart-sauce-labs-bike-light")));
            elementList.AddRange(Driver.FindElements(By.Id("add-to-cart-sauce-labs-fleece-jacket")));
            elementList.AddRange(Driver.FindElements(By.Id("add-to-cart-test.allthethings()-t-shirt-(red)")));

            foreach (var item in elementList)
            {
                item.Click();
            }
        }

        public void RemoveFromCart()
        {
            List<IWebElement> elementList = new List<IWebElement>();
            elementList.AddRange(Driver.FindElements(By.Id("remove-sauce-labs-backpack")));
            elementList.AddRange(Driver.FindElements(By.Id("remove-sauce-labs-bolt-t-shirt")));
            elementList.AddRange(Driver.FindElements(By.Id("remove-sauce-labs-onesie")));
            elementList.AddRange(Driver.FindElements(By.Id("remove-sauce-labs-bike-light")));
            elementList.AddRange(Driver.FindElements(By.Id("remove-sauce-labs-fleece-jacket")));
            elementList.AddRange(Driver.FindElements(By.Id("remove-test.allthethings()-t-shirt-(red)")));

            foreach (var item in elementList)
            {
                item.Click();
            }
        }      

        public bool IsElementPresent()
        {
            try
            {
                Driver.FindElement(By.XPath("//span[@class='shopping_cart_badge']"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
