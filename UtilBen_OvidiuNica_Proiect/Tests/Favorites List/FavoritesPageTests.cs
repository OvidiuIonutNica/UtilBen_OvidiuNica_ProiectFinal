using System;
using System.Collections.Generic;
using System.Text;
using UtilBen_OvidiuNica_Proiect.PageModels;
using UtilBen_OvidiuNica_Proiect.Utils;
using NUnit.Framework;
using System.Threading;

namespace UtilBen_OvidiuNica_Proiect.Tests.Logout
{
    class FavoritesPageTests : BaseTest
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
        public void FavoriteListTests(string email, string password)
        {

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);

            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();

            FavoritesPage fv = new FavoritesPage(_driver);
            fv.Favorites(email, password);
            Thread.Sleep(3000);


        }

    }
}

