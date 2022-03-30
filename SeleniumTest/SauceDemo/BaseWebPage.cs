using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTest.SauceDemo
{
    public class BaseWebPage
    {
        public readonly IWebDriver Driver;

        public string BaseUrl { get; }

        public BaseWebPage(IWebDriver driver)
        {
            Driver = driver;
            BaseUrl = "https://www.saucedemo.com";
        }
    }
}
