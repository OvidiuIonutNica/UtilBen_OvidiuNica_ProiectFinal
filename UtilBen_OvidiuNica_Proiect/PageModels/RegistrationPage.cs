using UtilBen_OvidiuNica_Proiect.PageModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace UtilBen_OvidiuNica_Proiect.PageModels
{
    public class RegistrationPage : BasePage
    {
        const string loginButtonPageSelector = "#HomeNavbar > ul:nth-child(7) > li:nth-child(2) > a > img"; // css
        const string registrationButtonSelector = "#login-modal > div > form > div.col-sm-12.margin-bottom-30 > a"; // css
        const string nameInputSelector = "Name"; // id
        const string emailInputSelector = "Email"; // id
        const string passwordInputSelector = "Password";// id
        const string confirmpasswordInputSelector = "ConfirmPassword"; //id
        const string registerButtonSelector = "//*[@id='wrapper']/div/div/div[2]/div/div/div[2]/form/div[9]/button"; //xpath
        const string negativeRegistrationMessageSelector = "error-message"; // id
        const string afirmativeRegistrationMessageSelector = "//*[contains(text(),'Buna ziua ')]"; // xpath
        public Boolean CheckNegativeRegistrationMessage(string message)
        {
            return String.Equals(message.ToLower(), driver.FindElement(By.Id(negativeRegistrationMessageSelector)).Text.ToLower());
        }

        public Boolean CheckAfirmativeRegistrationMessage(string message)
        {
            var loginButtonPage2 = driver.FindElement(By.CssSelector(loginButtonPageSelector));
            loginButtonPage2.Click();
            return driver.FindElement(By.XPath(afirmativeRegistrationMessageSelector)).Text.ToLower().Contains(message.ToLower());
        }

        public RegistrationPage(IWebDriver driver) : base(driver)
        {

        }

        public void RegisterUser(string name, string email, string password)
        {
            var loginButtonPage = driver.FindElement(By.CssSelector(loginButtonPageSelector));
            loginButtonPage.Click();
            var registrationButtonPage = driver.FindElement(By.CssSelector(registrationButtonSelector));
            registrationButtonPage.Click();
            var nameInput = driver.FindElement(By.Id(nameInputSelector));
            nameInput.Clear();
            nameInput.SendKeys(name);
            var emailInput = driver.FindElement(By.Id(emailInputSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passwordInput = driver.FindElement(By.Id(passwordInputSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var ConfirmPaswordInput = driver.FindElement(By.Id(confirmpasswordInputSelector));
            ConfirmPaswordInput.Clear();
            ConfirmPaswordInput.SendKeys(password);

            var submitButton = Utils.Utils.WaitForElementClickable(driver, 10, By.XPath(registerButtonSelector));
            submitButton.SendKeys(Keys.Return);

        }
    }
}