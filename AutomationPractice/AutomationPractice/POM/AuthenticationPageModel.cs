using AutomationPractice.Resource;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.POM
{
    public class AuthenticationPageModel : BasePageModel
    {
        public AuthenticationPageModel(SeleniumExtension seleniumExtensionObject):base(seleniumExtensionObject)
        {

        }

        private By authenticationHeader = By.CssSelector(".page-heading");

        #region Create Account
        private By createAccountEmailAddressField = By.CssSelector("#email_create");
        private By createSubmitButton = By.CssSelector("#SubmitCreate");
        private By createAccountEmailAddressError = By.CssSelector("#create-account_form .form-group.form-error");
        #endregion

        #region Sign In
        private By emailAddressField = By.CssSelector("#email");
        private By passwordField = By.CssSelector("#passwd");
        private By emailAddressError = By.CssSelector("#login_form .form-group.form-error");
        private By signInButton = By.CssSelector("#SubmitLogin");
        #endregion

        /// <summary>
        /// Check if Page is Loaded
        /// </summary>
        /// <returns></returns>
        public override bool IsPageLoaded()
        {
            return SeleniumExtensionObject.WaitForElementToBeVisible(authenticationHeader).Displayed;
        }

        /// <summary>
        /// Checks if Create Account - Email Address Field for Sign In form is Required
        /// </summary>
        /// <returns></returns>
        public bool IsCreateAccountEmailAddressFieldRequired()
        {
            SeleniumExtensionObject.Click(createAccountEmailAddressField);
            SeleniumExtensionObject.Click(authenticationHeader);

            return SeleniumExtensionObject.WaitForElementToBeVisible(createAccountEmailAddressError).Displayed;
        }

        /// <summary>
        /// Checks if Email Address Field for Sign In form is Required
        /// </summary>
        /// <returns></returns>
        public bool IsEmailAddressFieldRequired()
        {
            SeleniumExtensionObject.Click(emailAddressField);
            SeleniumExtensionObject.Click(authenticationHeader);

            return SeleniumExtensionObject.WaitForElementToBeVisible(emailAddressError).Displayed;
        }

        public CreateAnAccountPageModel CreateAccount(string emailAddress)
        {
            SeleniumExtensionObject.Inputvalue(createAccountEmailAddressField, emailAddress);
            SeleniumExtensionObject.Click(createSubmitButton);
            return new CreateAnAccountPageModel(this.SeleniumExtensionObject);
        }

        public MyAccountPageModel LoginAccount(string email, string password)
        {
            SeleniumExtensionObject.Inputvalue(emailAddressField,email);
            SeleniumExtensionObject.Inputvalue(passwordField, password);
            SeleniumExtensionObject.Click(signInButton);
            return new MyAccountPageModel(this.SeleniumExtensionObject);
        }
    }
}
