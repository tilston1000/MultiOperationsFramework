using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DropDownAndMultipleSelectOperations
{
    [TestClass]
    public class DropDownBoxOrList
    {
        [TestMethod]
        public void DropDownboxorListTest()
        {

            // Create a new instance of the Firefox driver
            IWebDriver driver = new ChromeDriver();

            // Put an Implicit wait, this means that any search for elements on the page could take the time the implicit wait is set for before throwing exception
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Launch the URL
            driver.Url = "http://toolsqa.wpengine.com/automation-practice-form";

            // Step 3: Select 'Continents' Drop down ( Use Id to identify the element )
            // Find Select element of "Single selection" using ID locator.
            SelectElement oSelection = new SelectElement(driver.FindElement(By.Id("continents")));

            // Step 4:) Select option 'Europe' (Use selectByIndex)
            oSelection.SelectByText("Europe");

            // Using sleep command so that changes can be notice
            Thread.Sleep(2000);

            // Step 5: Select option 'Africa' now (Use selectByVisibleText)
            oSelection.SelectByIndex(2);
            Thread.Sleep(2000);

            // Step 6: Print all the options for the selected drop down and select one option of your choice
            // Get the size of the Select element
            IList<IWebElement> oSize = oSelection.Options;

            int iListSize = oSize.Count;
            // Setting up the loop to print all the options
            for (int i = 0; i < iListSize; i++)
            {
                // Storing the value of the option	
                String sValue = oSelection.Options.ElementAt(i).Text;
                // Printing the stored value
                Console.WriteLine("Value of the Select item is : " + sValue);

                // Putting a check on each option that if any of the option is equal to 'Africa" then select it 
                if (sValue.Equals("Africa"))
                {
                    oSelection.SelectByIndex(i);
                    break;
                }

            }

            // Kill the browser
            driver.Close();
        }
    }
}
