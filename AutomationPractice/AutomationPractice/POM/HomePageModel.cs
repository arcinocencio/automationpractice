using AutomationPractice.Resource;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.POM
{
    public class HomePageModel : BasePageModel
    {

        public HomePageModel(SeleniumExtension seleniumExtensionObject) : base(seleniumExtensionObject)
        {
        }

        #region Elements

        private By logo = By.CssSelector(".logo");
        private By signInButton = By.CssSelector(".login");
        private By contactUsButton = By.CssSelector("#contact-link");
        private By popularTab = By.CssSelector("a[href='#homefeatured']");

        #endregion

        #region Methods
        public void OpenURL()
        {
            SeleniumExtensionObject.WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("WebsiteURL"));

        }

        public AuthenticationPageModel NavigateToAuthenticationPage()
        {
            OpenURL();
            SeleniumExtensionObject.Click(signInButton);
            return new AuthenticationPageModel(this.SeleniumExtensionObject);
        }

        #endregion

        public override bool IsPageLoaded()
        {
            return SeleniumExtensionObject.WaitForElementToBeVisible(popularTab).Displayed;
        }
    }
}
