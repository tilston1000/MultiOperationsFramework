using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HandlingAlertsAndPopupBoxes
{
    [TestClass]
    public class ConfirmationAlerts
    {
        [TestMethod]
        public void ConfirmationAlertsTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
            driver.Manage().Window.Maximize();

            //This step produce an alert on screen
            IWebElement element = driver.FindElement(By.XPath("//*[@id='content']/p[8]/button"));

            // 'IJavaScriptExecutor' is an interface which is used to run the 'JavaScript code' into the webdriver (Browser)
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

            // Switch the control of 'driver' to the Alert from main window
            IAlert confirmationAlert = driver.SwitchTo().Alert();

            // Get the Text of Alert
            String alertText = confirmationAlert.Text;

            Console.WriteLine("Alert text is " + alertText);

            //'.Dismiss()' is used to cancel the alert '(click on the Cancel button)'
            confirmationAlert.Dismiss();

            driver.Quit();
        }
    }
}
