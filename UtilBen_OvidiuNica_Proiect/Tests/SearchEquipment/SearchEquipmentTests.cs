using System;
using System.Collections.Generic;
using System.Text;
using UtilBen_OvidiuNica_Proiect.PageModels;
using UtilBen_OvidiuNica_Proiect.Utils;
using NUnit.Framework;
using System.Threading;

namespace UtilBen_OvidiuNica_Proiect.Tests.SearchEquipment
{
    public class SearchEquipmentTests : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv()
        {
            foreach (var values in Utils.Utils.GetGenericData("TestData\\authenticationDataAfirmative.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test, TestCaseSource("GetCredentialsDataCsv")]
        [Category("Search Equipments")]

        public void SearchEquipment(string email, string pass)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();
            LoginPage lp2 = new LoginPage(_driver);
            lp2.Login(email, pass);
            Assert.IsTrue(lp2.CheckAfirmativeLoginonMessage("Buna ziua "));
            Thread.Sleep(3000);
            mp.SearchEquipment();

        }
    }
}
