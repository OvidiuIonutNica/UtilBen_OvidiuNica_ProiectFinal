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
    public class LogoutPage : BasePage
    {
        const string emailSelector = "Email"; // id
        const string passwordSelector = "Password"; //id
        const string loginButtonPageSelector = "#HomeNavbar > ul:nth-child(7) > li:nth-child(2) > a > img"; // css
        const string loginButtonSelector = "#login-modal > div > form > div:nth-child(5) > button"; // css
        const string logoutButtonSelector = "#logoutForm > a"; // css

        public LogoutPage(IWebDriver driver) : base(driver)
        {

        }

        public void Logout(string email, string password)
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
            var loginButtonPage2 = driver.FindElement(By.CssSelector(loginButtonPageSelector));
            loginButtonPage2.Click();
            var logoutButtonPage = driver.FindElement(By.CssSelector(logoutButtonSelector));
            logoutButtonPage.Click();
        }
    }
}