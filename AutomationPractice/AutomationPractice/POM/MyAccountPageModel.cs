using AutomationPractice.Resource;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.POM
{
    public class MyAccountPageModel : BasePageModel
    {
        public MyAccountPageModel(SeleniumExtension seleniumExtensionObject):base(seleniumExtensionObject)
        {
            IsPageLoaded();
        }

        #region Elements
        private By userInfoHeader = By.CssSelector(".account span");
        private By myAccountHeader = By.CssSelector(".page-heading");
        private By HomeButton = By.CssSelector("a[title='Home']");
        #endregion

        #region Methods
        public bool IsUserFirstNameLastNameDisplayedCorrectly(string firstName, string lastName)
        {
            string fullName = SeleniumExtensionObject.GetText(userInfoHeader);
            return fullName == $"{firstName} {lastName}";
        }

        public HomePageModel NavigateToHomePage()
        {
            SeleniumExtensionObject.Click(HomeButton);
            return new HomePageModel(this.SeleniumExtensionObject);
        }
        #endregion

        public override bool IsPageLoaded()
        {
            return SeleniumExtensionObject.WaitForElementToBeVisible(myAccountHeader).Displayed;
        }
    }
}
