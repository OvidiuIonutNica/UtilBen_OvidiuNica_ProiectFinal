using System;
using System.Collections.Generic;
using System.Text;
using UtilBen_OvidiuNica_Proiect.PageModels;
using UtilBen_OvidiuNica_Proiect.Utils;
using NUnit.Framework;
using System.Threading;

namespace UtilBen_OvidiuNica_Proiect.Tests.Register
{
    class RegistrationTestsAfirmativ : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv2()
        {
            foreach (var values in Utils.Utils.GetGenericData("TestData\\registerData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test]
        [Category("Registration")]
        public void RegisterTest()
        {

            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);
            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();

            _driver.Navigate().GoToUrl(url + registrationUrlPath);
            RegistrationPage rp = new RegistrationPage(_driver);
            rp.RegisterUser(Utils.Utils.GenerateRandomStringCount(10), Utils.Utils.GenerateRandomStringCount(10) + "@test.com", Utils.Utils.GenerateRandomStringCount(10) );
            Assert.IsTrue(rp.CheckAfirmativeRegistrationMessage("Buna ziua"));  
            Thread.Sleep(3000);
        }

    }
}
