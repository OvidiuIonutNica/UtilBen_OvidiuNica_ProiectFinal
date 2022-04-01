using UtilBen_OvidiuNica_Proiect.PageModels;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace UtilBen_OvidiuNica_Proiect.PageModels
{
    public class MainPage : BasePage
    {

        const string acceptCookiesSelector = "consent"; // id  
        const string branddropdown = "brandDDL"; // id
        const string searchEquipment = "searchEquipment"; //id
        const string loginButtonPageSelector = "#HomeNavbar > ul:nth-child(7) > li:nth-child(2) > a > img"; // css
        const string favoritesButtonSelector = "#login-modal > div > div.col-12.login-modal-links > div > div:nth-child(2) > a"; // css
        const string category = "#TypesModal";
        const string favoriteButton = "#favorite > button > img"; //css

        public IWebElement BrandDropDown => Utils.Utils.FindElementWait(driver, By.Id(branddropdown));
        public IWebElement CategoryDropDown => Utils.Utils.FindElementWait(driver, By.Id(category));
        public IWebElement FavoriteProduct => Utils.Utils.FindElementWait(driver, By.XPath("//a[contains(@class, 'no-decoration') and text() = 'John Deere C670i HillMaster']"));

        public MainPage(IWebDriver driver) : base(driver)
        {

        }
        public void AcceptCookies()
        {
            driver.FindElement(By.Id(acceptCookiesSelector)).Click();
        }
        public void SearchEquipment()
        {

            //search

            //aici am vrut sa ii fac cautare dupa categorie, dar nu am reusit
            //Utils.Utils.SelectFromDropDown(BrandDropDown, "Tractoare", "Text");
            //var searchCategory = driver.FindElement(By.Id(category));
            //searchCategory.Click();

            Utils.Utils.SelectFromDropDown(BrandDropDown, "39", "Value");
            var searchEquipments = driver.FindElement(By.Id(searchEquipment));
            searchEquipments.Click();
            FavoriteProduct.Click();
            var fav = driver.FindElement(By.CssSelector(favoriteButton));
            if (fav.Displayed)
               { 
                fav.Click();
                var loginButtonPage2 = driver.FindElement(By.CssSelector(loginButtonPageSelector));
                loginButtonPage2.Click();
                var favoriteButtonPage = driver.FindElement(By.CssSelector(favoritesButtonSelector));
                favoriteButtonPage.Click();
            }
            else
            {
                var loginButtonPage2 = driver.FindElement(By.CssSelector(loginButtonPageSelector));
                loginButtonPage2.Click();
                var favoriteButtonPage = driver.FindElement(By.CssSelector(favoritesButtonSelector));
                favoriteButtonPage.Click();
            }
           
        }


    }
}
