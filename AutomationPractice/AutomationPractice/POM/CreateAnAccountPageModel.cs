using AutomationPractice.Resource;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.POM
{
    public class CreateAnAccountPageModel : BasePageModel
    {
        public CreateAnAccountPageModel(SeleniumExtension seleniumExtensionObject) : base(seleniumExtensionObject)
        {
            IsPageLoaded();
        }

        #region Your Personal Information
        private By createAnAccountHeader = By.CssSelector(".page-heading");
        private By titleMr = By.CssSelector("#id_gender1");
        private By titleMrs = By.CssSelector("#id_gender2");
        private By firstNameField = By.CssSelector("#customer_firstname");
        private By lastNameField = By.CssSelector("#customer_lastname");
        private By emailField = By.CssSelector("#email");
        private By passwordField = By.CssSelector("#passwd");
        private By DOBDay = By.CssSelector("#days");
        private By DOBMonth = By.CssSelector("#months");
        private By DOBYear = By.CssSelector("#years");
        private By signUpNewsLetterCheckbox = By.CssSelector("#newsletter");
        private By specialOfferCheckbox = By.CssSelector("#newsletter");
        #endregion

        #region Your Address
        private By firstNameAddress = By.CssSelector("#firstname");
        private By lastNameAddress = By.CssSelector("#lastname");
        private By companyAddress = By.CssSelector("#company");
        private By address1Field = By.CssSelector("#address1");
        private By address2Field = By.CssSelector("#address2");
        private By cityAddress = By.CssSelector("#city");
        private By stateAddress = By.CssSelector("#id_state");
        private By postalCode = By.CssSelector("#postcode");
        private By countryAddress = By.CssSelector("#id_country");
        private By additionalInformation = By.CssSelector("#other");
        private By homePhoneAddress = By.CssSelector("#phone");
        private By mobilePhoneAddress = By.CssSelector("#phone_mobile");
        private By addressAlias = By.CssSelector("#alias");
        #endregion

        private By registerButton = By.CssSelector("#submitAccount");

        public override bool IsPageLoaded()
        {
            return SeleniumExtensionObject.WaitForElementToBeVisible(createAnAccountHeader).Displayed;
        }

        public bool IsEmailAddressAutoPopulated(string emailAddress)
        {
            var defaultValue = SeleniumExtensionObject.GetText(emailField);
            return emailAddress == defaultValue;
        }

        /// <summary>
        /// Enter Personal Information
        /// </summary>
        /// <param name="title"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="clickNewsLetter"></param>
        /// <param name="clickSpecialOffer"></param>
        public void EnterPersonalInformation(
            string title, 
            string firstName, 
            string lastName, 
            string password, 
            string day,
            string month,
            string year,
            string clickNewsLetter = "no",
            string clickSpecialOffer = "no"
            )
        {
           switch(title)
            {
                case "Mr":
                    SeleniumExtensionObject.Click(titleMr);
                    break;
                case "Mrs":
                    SeleniumExtensionObject.Click(titleMrs);
                    break;
            }
            SeleniumExtensionObject.Inputvalue(firstNameField, firstName);
            SeleniumExtensionObject.Inputvalue(lastNameField, lastName);
            SeleniumExtensionObject.Inputvalue(passwordField, password);
            SeleniumExtensionObject.SelectDropdownOptionByValue(DOBDay, day);
            SeleniumExtensionObject.SelectDropdownOptionByValue(DOBMonth, month);
            SeleniumExtensionObject.SelectDropdownOptionByValue(DOBYear, year);
            if (clickNewsLetter == "yes") SeleniumExtensionObject.Click(signUpNewsLetterCheckbox);
            if (clickSpecialOffer == "yes") SeleniumExtensionObject.Click(specialOfferCheckbox);
        }

        public void EnterAddressInfo(string firstName, 
            string lastName, 
            string company, 
            string address1, 
            string address2, 
            string city, 
            string state, 
            string postal, 
            string country,
            string additionInfo,
            string homePhone,
            string mobilePhone,
            string aliasAddress)
        {
            SeleniumExtensionObject.Inputvalue(firstNameAddress, firstName);
            SeleniumExtensionObject.Inputvalue(lastNameAddress, lastName);
            SeleniumExtensionObject.Inputvalue(companyAddress, company);
            SeleniumExtensionObject.Inputvalue(address1Field, address1);
            SeleniumExtensionObject.Inputvalue(address2Field, address2);
            SeleniumExtensionObject.Inputvalue(cityAddress, city);
            SeleniumExtensionObject.SelectDropdownOptionByText(stateAddress, state);
            SeleniumExtensionObject.Inputvalue(postalCode, postal);
            SeleniumExtensionObject.SelectDropdownOptionByText(countryAddress, country);
            SeleniumExtensionObject.Inputvalue(additionalInformation, additionInfo);
            SeleniumExtensionObject.Inputvalue(homePhoneAddress, homePhone);
            SeleniumExtensionObject.Inputvalue(mobilePhoneAddress, mobilePhone);
            SeleniumExtensionObject.Inputvalue(addressAlias, aliasAddress);
        }

        public void ClickRegisterButton()
        {
            SeleniumExtensionObject.Click(registerButton);
        }

        public MyAccountPageModel CreateAccount(
            string title,
            string firstName,
            string lastName,
            string password,
            string day,
            string month,
            string year,
            string clickNewsLetter,
            string clickSpecialOffer,
            string company,
            string address1,
            string address2,
            string city,
            string state,
            string postal,
            string country,
            string additionInfo,
            string homePhone,
            string mobilePhone,
            string aliasAddress)
        {
            SeleniumExtensionObject.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            EnterPersonalInformation(
                title,
                firstName,
                lastName,
                password,
                day,
                month,
                year,
                clickNewsLetter,
                clickSpecialOffer);
            EnterAddressInfo(
                firstName,
                lastName,
                company,
                address1,
                address2,
                city,
                state,
                postal,
                country,
                additionInfo,
                homePhone,
                mobilePhone,
                aliasAddress);
            ClickRegisterButton();
            return new MyAccountPageModel(this.SeleniumExtensionObject);
        }

    }
}
