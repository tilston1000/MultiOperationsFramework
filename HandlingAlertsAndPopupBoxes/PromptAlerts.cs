using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HandlingAlertsAndPopupBoxes
{
    [TestClass]
    public class PromptAlerts
    {
        [TestMethod]
        public void PromptAlertTest()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
            driver.Manage().Window.Maximize();

            //This step produce an alert on screen
            IWebElement element = driver.FindElement(By.XPath("//*[@id='content']/p[11]/button"));

            // 'IJavaScriptExecutor' is an 'interface' which is used to run the 'JavaScript code' into the webdriver (Browser)        
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

            // Switch the control of 'driver' to the Alert from main window
            IAlert promptAlert = driver.SwitchTo().Alert();

            // Get the Text of Alert
            String alertText = promptAlert.Text;
            Console.WriteLine("Alert text is " + alertText);

            //'.SendKeys()' to enter the text in to the textbox of alert 
            promptAlert.SendKeys("Accepting the alert");

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            promptAlert.Accept();

            driver.Quit();
        }
    }
}
