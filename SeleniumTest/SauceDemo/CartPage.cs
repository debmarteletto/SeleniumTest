using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumTest.SauceDemo
{
    public class CartPage : BaseWebPage
    {
        private readonly string _pageUrl;
        public CartPage(IWebDriver driver) : base(driver)
        {
            _pageUrl = "cart.html";
        }
        public CartPage Open()
        {
            Driver.Navigate().GoToUrl($"{BaseUrl}/{_pageUrl}");
            return this;
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
                if (IsElementPresentById(item))
                    item.Click();
            }           
        }

        private bool IsElementPresentById(IWebElement element)
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

        public bool IsAnyElementPresent()
        {
            try
            {
                Driver.FindElement(By.Id("cart_item"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
