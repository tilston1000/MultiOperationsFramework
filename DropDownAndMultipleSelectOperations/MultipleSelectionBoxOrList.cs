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
    public class MultipleSelectionBoxOrList
    {
        [TestMethod]
        public void MultipleSelectionBoxOrListTest()
        {
            // Create a new instance of the Chrome driver
            IWebDriver driver = new ChromeDriver();

            // Put an Implicit wait, this means that any search for elements on the page could take the time the implicit wait is set for before throwing exception
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // Launch the URL
            driver.Url = "http://toolsqa.wpengine.com/automation-practice-form";

            // Step 3: Select 'Selenium Commands' Multiple select box ( Use Name locator to identify the element )
            SelectElement oSelection = new SelectElement(driver.FindElement(By.Name("selenium_commands")));

            // Step 4: Select option 'Browser Commands'  and then deselect it (Use selectByIndex and deselectByIndex)
            oSelection.SelectByIndex(0);
            Thread.Sleep(2000);
            oSelection.DeselectByIndex(0);

            // Step 5: Select option 'Navigation Commands'  and then deselect it (Use selectByVisibleText and deselectByVisibleText)
            oSelection.SelectByText("Navigation Commands");
            Thread.Sleep(2000);

            oSelection.DeselectByText("Navigation Commands");

            // Step 6: Print and select all the options for the selected Multiple selection list.
            IList<IWebElement> oSize = oSelection.Options;
            int iListSize = oSize.Count;

            // Setting up the loop to print all the options
            for (int i = 0; i < iListSize; i++)
            {
                // Storing the value of the option	
                String sValue = oSelection.Options.ElementAt(i).Text;
                // Printing the stored value
                Console.WriteLine("Value of the Item is :" + sValue);
                // Selecting all the elements one by one
                oSelection.SelectByIndex(i);

                Thread.Sleep(2000);
            }

            // Step 7: Deselect all
            oSelection.DeselectAll();

            // Kill the browser
            driver.Close();

        }
    }
}
