using AutomationPractice.POM;
using AutomationPractice.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutomationPractice
{
    [TestClass]
    public class AuthenticationTests : BaseTest

    {
        string title = "Mr";
        string firstName = "Aaron";
        string lastName = "Ino";
        string password = "password";
        string email = "test3@arci.com";
        string day = "12";
        string month = "4";
        string year = "1992";
        string checkNewsLetter = "yes";
        string checkSpecialOffer = "yes";
        string company = "ProSource";
        string address1 = "Makati";
        string address2 = "Laguna";
        string city = "Lindon";
        string postal = "84042";
        string state = "Utah";
        string country = "United States";
        string additionalInfo = "Turn Right then Turn Left";
        string homePhone = "+639991234567";
        string mobilePhone = "+639991234568";
        string alias = "A.K.A. Address";

        [TestMethod]
        public void IsEmailAddressFieldsRequired()
        {
            HomePageModel homePage = new HomePageModel(this.SeleniumExtensionObject);
            AuthenticationPageModel authentication = homePage.NavigateToAuthenticationPage();
            Assert.IsTrue(authentication.IsCreateAccountEmailAddressFieldRequired());
            Assert.IsTrue(authentication.IsEmailAddressFieldRequired());
        }

        /// <summary>
        /// Verify that customer can create account
        /// Verify that user is navigated to My Account upon account creation
        /// </summary>
        [TestMethod]
        public void CreateAccount()
        {
            HomePageModel homePage = new HomePageModel(this.SeleniumExtensionObject);
            AuthenticationPageModel authentication = homePage.NavigateToAuthenticationPage();
            CreateAnAccountPageModel createAccount = authentication.CreateAccount(email);
            MyAccountPageModel myAccount = createAccount.CreateAccount(
                title,
                firstName,
                lastName,
                password,
                day,
                month,
                year,
                checkNewsLetter,
                checkSpecialOffer,
                company,
                address1,
                address2,
                city,
                state,
                postal,
                country,
                additionalInfo,
                homePhone,
                mobilePhone,
                alias);
            Assert.IsTrue(myAccount.IsUserFirstNameLastNameDisplayedCorrectly(firstName,lastName));
            Assert.IsTrue(myAccount.IsPageLoaded());
        }

        /// <summary>
        /// Verify user can login created account
        /// Verify user is navigated to My Account upon logged in
        /// </summary>
        [TestMethod]
        public void LoginAccount()
        {
            HomePageModel homePage = new HomePageModel(this.SeleniumExtensionObject);
            AuthenticationPageModel authentication = homePage.NavigateToAuthenticationPage();
            MyAccountPageModel myAccount = authentication.LoginAccount(email, password);
            Assert.IsTrue(myAccount.IsUserFirstNameLastNameDisplayedCorrectly(firstName, lastName));
            Assert.IsTrue(myAccount.IsPageLoaded());
        }
    }
}