using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Resource
{
    public class SeleniumExtension
    {
        public IWebDriver WebDriver { get; set; }

        public SeleniumExtension(IWebDriver webdriver) => this.WebDriver = webdriver;

        public IWebElement ForClickableElementAndScrollingIntoView(By pageElement)
        {
            try
            {
                var element = WebDriver.FindElement(pageElement);
                ((IJavaScriptExecutor)WebDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                return WaitForElementToBeVisible(pageElement);
            }
            catch (NoSuchElementException)
            {
                throw new NoSuchElementException("Element does not exist");
            }
        }

        public IWebElement WaitForElementToBeVisible(By by, int timeoutInSeconds = 5)
        {
            try
            {
                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(driver => driver.FindElement(by));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Element is either not displayed in a given wait time or does not exist. {by}");
            }
        }

        public void Click(By element) => WaitForElementToBeVisible(element).Click();
        public void Inputvalue(By element, string value)
        {
            WaitForElementToBeVisible(element).Clear();
            WaitForElementToBeVisible(element).SendKeys(value);
        }
        public string GetText(By element) => WaitForElementToBeVisible(element).Text;
        public void SelectDropdownOptionByValue(By element, string value)
        {
            var selectElement = new SelectElement(WaitForElementToBeVisible(element));
            selectElement.SelectByValue(value);
        }
        public void SelectDropdownOptionByText(By element, string value)
        {
            var selectElement = new SelectElement(WaitForElementToBeVisible(element));
            selectElement.SelectByText(value);
        }
    }
}
