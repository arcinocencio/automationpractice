using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Resource
{
    class WebDriverFactory
    {
        public enum DriverType
        {
            Chrome
        }
        public static IWebDriver GetWebDriver(string driverType)
        {
            try
            {
                var driver = (DriverType)Enum.Parse(typeof(DriverType), driverType, true);
                switch (driver)
                {
                    case DriverType.Chrome:
                        return new ChromeDriver(".", (ChromeOptions)GetDriverOptions(driver));
                    //can add multiple DriverType
                    //Firefox etc...
                    default:
                        return null;
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"'{driverType}' web driver not supported. \n Exception Message: {ex.Message}");
            }
        }
        private static DriverOptions GetDriverOptions(DriverType driverType)
        {
            ChromeOptions chromeOptions = new ChromeOptions();

            switch (driverType)
            {
                case DriverType.Chrome:
                    return chromeOptions;
                //can add multiple driver options
                //Firefox etc...
                default:
                    return null;
            }
        }
    }
}
