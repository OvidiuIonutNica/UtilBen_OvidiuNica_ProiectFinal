using System;
using System.Collections.Generic;
using System.Text;
using UtilBen_OvidiuNica_Proiect.PageModels;
using UtilBen_OvidiuNica_Proiect.Utils;
using NUnit.Framework;
using System.Threading;

namespace UtilBen_OvidiuNica_Proiect.Tests.Register
{
    class RegistrationTestsNegativ : BaseTest
    {
        string url = FrameworkConstants.GetUrl();

        private static IEnumerable<TestCaseData> GetCredentialsDataCsv2()
        {
            foreach (var values in Utils.Utils.GetGenericData("TestData\\registerData.csv"))
            {
                yield return new TestCaseData(values);
            }
        }

        [Test, TestCaseSource("GetCredentialsDataCsv2")]
        [Category("Registration")]
        public void RegisterTestNegativ(string name, string email, string pass)
        {
            testName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(testName);
            _driver.Navigate().GoToUrl(url);

            MainPage mp = new MainPage(_driver);
            mp.AcceptCookies();

            RegistrationPage reg = new RegistrationPage(_driver);
            reg.RegisterUser(name, email, pass);
            Assert.IsTrue(reg.CheckNegativeRegistrationMessage("Name ovidiuionut.nica@gmail.com is already taken."));  
            Thread.Sleep(3000);

        }
    }
}
