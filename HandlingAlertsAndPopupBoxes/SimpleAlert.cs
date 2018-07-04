using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HandlingAlertsAndPopupBoxes
{
    [TestClass]
    public class SimpleAlert
    {
        [TestMethod]
        public void SimpleAlertTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
            driver.Manage().Window.Maximize();

            //This step produce an alert on screen
            driver.FindElement(By.XPath("//*[@id='content']/p[4]/button")).Click();

            // Switch the control of 'driver' to the Alert from main Window
            IAlert simpleAlert = driver.SwitchTo().Alert();

            // '.Text' is used to get the text from the Alert
            String alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is " + alertText);

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            simpleAlert.Accept();

            driver.Quit();

        }
    }
}
