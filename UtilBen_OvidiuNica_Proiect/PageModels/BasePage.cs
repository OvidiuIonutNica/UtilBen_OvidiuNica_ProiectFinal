
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilBen_OvidiuNica_Proiect.PageModels
{
    public class BasePage
    {

        public IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
