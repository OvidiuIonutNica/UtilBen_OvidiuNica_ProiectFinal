
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilBen_OvidiuNica_Proiect.PageModels
{
    public class LoginPage : BasePage
    {

        const string emailSelector = "Email"; // id
        const string passwordSelector = "Password"; //id
        const string loginButtonPageSelector = "#HomeNavbar > ul:nth-child(7) > li:nth-child(2) > a > img"; // css
        const string loginButtonSelector = "#login-modal > div > form > div:nth-child(5) > button"; // css
        const string negativeLoginMessageSelector = "error-message"; // id
        const string afirmativeLoginMessageSelector = "//*[contains(text(),'Buna ziua ')]"; // xpath

        public Boolean CheckNegativeLoginMessage(string message)
        {
            return String.Equals(message.ToLower(), driver.FindElement(By.Id(negativeLoginMessageSelector)).Text.ToLower());
        }

        public Boolean CheckAfirmativeLoginonMessage(string message)
        {
            var loginButtonPage2 = driver.FindElement(By.CssSelector(loginButtonPageSelector));
            loginButtonPage2.Click();
            return driver.FindElement(By.XPath(afirmativeLoginMessageSelector)).Text.ToLower().Contains(message.ToLower());
        }

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }


        public void Login(string email, string password)
        {
            var loginButtonPage = driver.FindElement(By.CssSelector(loginButtonPageSelector));
            loginButtonPage.Click();
            var emailInput = driver.FindElement(By.Id(emailSelector));
            emailInput.Clear();
            emailInput.SendKeys(email);
            var passwordInput = driver.FindElement(By.Id(passwordSelector));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            var loginButton = driver.FindElement(By.CssSelector(loginButtonSelector));
            loginButton.Click();
        }

    }
}
