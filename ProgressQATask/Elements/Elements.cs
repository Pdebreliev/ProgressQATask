using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ProgressQATask.Elements
{
    public class WebPageAutomation
    {
        private IWebDriver driver;

        public void PerformAutomation()
        {
            // Elements located by Xpath and IDs
            IWebElement Uploadbutton = driver.FindElement(By.Id("uploadButton"));
            IWebElement Username = driver.FindElement(By.XPath("//input[@id='form_username']"));
            IWebElement Password = driver.FindElement(By.XPath("//input[@id='form_password']"));
            IWebElement SignOnButton = driver.FindElement(By.XPath("//span[contains(text(),'Sign On')]"));
            IWebElement ContactsButton = driver.FindElement(By.Id("tab_contacts"));
            IWebElement AddContactsButton = driver.FindElement(By.XPath("//span[contains(text(),'Add contact')]"));
            IWebElement AddContactButton = driver.FindElement(By.XPath("//span[text()='Add contact']"));
            IWebElement Packages = driver.FindElement(By.Id("tab_messaging"));
            IWebElement SendPackages = driver.FindElement(By.XPath("//span[contains(text(),'Send Package')]"));
            IWebElement ToField = driver.FindElement(By.Id("tofield"));
            IWebElement SubjectField = driver.FindElement(By.Id("fieldsubject"));
            IWebElement BodyField = driver.FindElement(By.XPath("//body"));
            IWebElement SendButton = driver.FindElement(By.Id("send-button"));
        }
        [TestClass]
        public class SendPackageTest
        {
            private IWebDriver driver;

            [TestInitialize]
            public void TestInitialize()
            {
                // Initialize the Chrome driver
                driver = new ChromeDriver();

                // Step 1: Login to the page (Prerequisite)
                driver.Navigate().GoToUrl("https://yourpage.com");

                // Assuming you have username and password fields, and a login button
                IWebElement Username = driver.FindElement(By.XPath("//input[@id='form_username']"));
                IWebElement Password = driver.FindElement(By.XPath("//input[@id='form_password']"));
                IWebElement SignOnButton = driver.FindElement(By.XPath("//span[contains(text(),'Sign On')]"));

                // Enter your login credentials
                Username.SendKeys("interview.plamen.debreliev");
                Password.SendKeys("BYn=76WL");

                // Click the login button
                SignOnButton.Click();

                // You can add assertions here to verify successful login if needed.
            }

            [TestMethod]
            public void SendPackage()
            {
                // Step 1: Go to the "Packages" section
                IWebElement Packages = driver.FindElement(By.Id("tab_messaging"));
                Packages.Click();

                // Step 2: Click the "Send Package" button
                IWebElement SendPackages = driver.FindElement(By.XPath("//span[contains(text(),'Send Package')]"));
                SendPackages.Click();

                // Step 3: Type "test@test.com" in the "To" section
                IWebElement ToField = driver.FindElement(By.Id("tofield"));
                ToField.SendKeys("test@test.com");

                // Step 4: Type "test1" in the "Subject" section
                IWebElement SubjectField = driver.FindElement(By.Id("fieldsubject"));
                SubjectField.SendKeys("test1");

                // Step 5: Type "test test" in the "Body" section
                IWebElement BodyField = driver.FindElement(By.XPath("//body"));
                BodyField.SendKeys("test test");

                // Step 6: Click the "Send" button
                IWebElement SendButton = driver.FindElement(By.Id("send-button"));
                SendButton.Click();

                // Verify the confirmation message
                IWebElement confirmationMessage = driver.FindElement(By.Id("confirmationMessage"));
                string actualMessage = confirmationMessage.Text;
                string expectedMessage = "Sent package with ID '' OK.";
                Assert.AreEqual(expectedMessage, actualMessage);
            }

            [TestCleanup]
            public void TestCleanup()
            {
                // Close the browser when the test is finished
                driver.Quit();
            }
        }
        [TestClass]
        public class LoginTest
        {
            private IWebDriver driver;

            [TestInitialize]
            public void TestInitialize()
            {
                // Initialize the Chrome driver
                driver = new ChromeDriver();
            }

            [TestMethod]
            public void LoginWithTestData()
            {
                // Step 1: Go to the site
                string url = "https://testserver.moveitcloud.com/";
                driver.Navigate().GoToUrl(url);

                // Step 2: Enter Username
                IWebElement Username = driver.FindElement(By.XPath("//input[@id='form_username']"));
                Username.SendKeys("interview.plamen.debreliev");

                // Step 3: Enter Password
                IWebElement Password = driver.FindElement(By.XPath("//input[@id='form_password']"));
                Password.SendKeys("BYn=76WL");

                // Step 4: Click Submit
                IWebElement SignOnButton = driver.FindElement(By.XPath("//span[contains(text(),'Sign On')]"));
                SignOnButton.Click();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                // Close the browser when the test is finished
                driver.Quit();
            }
        }

    }
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            // Initialize the Chrome driver
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void LoginWithInvalidCredentials()
        {
            // Step 1: Go to the site
            string url = "https://testserver.moveitcloud.com/";
            driver.Navigate().GoToUrl(url);

            // Step 2: Enter Username
            IWebElement Username = driver.FindElement(By.XPath("//input[@id='form_username']"));
            Username.SendKeys("interview.plamen.debreliev");

            // Step 3: Enter Password
            IWebElement Password = driver.FindElement(By.XPath("//input[@id='form_password']"));
            Password.SendKeys("alabala1");

            // Step 4: Click Submit
            IWebElement SignOnButton = driver.FindElement(By.XPath("//span[contains(text(),'Sign On')]"));
            SignOnButton.Click();

            // Expected Result: Verify that an error message appears
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[contains(text(),'Invalid username/password or not allowed to sign on from this location.')]"));
            Assert.IsTrue(errorMessage.Displayed, "Error message should appear: 'Invalid username/password or not allowed to sign on from this location.'");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Close the browser when the test is finished
            driver.Quit();
        }

    }
}

