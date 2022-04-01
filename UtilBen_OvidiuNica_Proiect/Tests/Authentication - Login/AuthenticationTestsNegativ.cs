using NUnit.Framework;
using UtilBen_OvidiuNica_Proiect.Tests;
using UtilBen_OvidiuNica_Proiect.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UtilBen_OvidiuNica_Proiect.PageModels;
using System.Threading;

namespace UtilBen_OvidiuNica_Proiect.Tests.Authentication
{
    public class AuthenticationTestsNegativ : BaseTest
    {

        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utils.Utils.GetGenericData("TestData\\authenticationDataNegative.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test, TestCaseSource("GetCredentialsDataCsv")]
        [Category("Authentication")]
        public void AuthenticationNegative(string email, string pass)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);

            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();

            LoginPage lp = new LoginPage(_driver);
             lp.Login(email, pass);
            Assert.IsTrue(lp.CheckNegativeLoginMessage("Datele de login sunt gresite sau inexistente. Daca nu aveti cont, va rugam sa va inregistrati."));  
            Thread.Sleep(5000);

        }


    }
}
