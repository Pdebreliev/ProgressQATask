using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProgressQATask.Elements;
using System.Security.Policy;

namespace ProgressQATask.AutomationTests
{
    public class AutomationTests : WebPageAutomation
    {
        private IWebDriver driver;
        private WebPageAutomation _webPageAutomation;        

        [TestClass]
        public class WebAutomationTests
        {
            private IWebDriver driver;

            [TestInitialize]
            public void TestInitialize()
            {               
                driver = new ChromeDriver();
            }

            [Test]
            public void SendingPackageWithAttachment()
            {
                string url = "https://testserver.moveitcloud.com/";
                driver.Navigate().GoToUrl(url);                
                
            }

            [TestCleanup]
            public void TestCleanup()
            {
                driver.Quit();
            }
        }
        [Test]
        public void SendingPackageWithAttachment() 
        {
            
        }
    }
}

