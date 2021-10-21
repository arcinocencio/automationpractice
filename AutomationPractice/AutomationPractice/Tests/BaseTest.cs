using AutomationPractice.Resource;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Tests
{
    public class BaseTest
    {
        public SeleniumExtension SeleniumExtensionObject { get; set; }

        public BaseTest()
        {
            SeleniumExtensionObject = new SeleniumExtension(WebDriverFactory.GetWebDriver(ConfigurationManager.AppSettings.Get("Browser")));
        }

        public void CloseBrowser()
        {
            SeleniumExtensionObject.WebDriver.Dispose();
        }

        [TestInitialize]
        public void TestSetup()
        {
            SeleniumExtensionObject.WebDriver.Manage().Window.Maximize();
        }


        [TestCleanup]
        public void close_Browser()
        {
            CloseBrowser();
        }

    }
}
