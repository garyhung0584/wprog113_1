using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace MyDrawingForm
{

    [TestClass]
    public class MyDrawingFormUITest
    {
        private const string WinAppDriverUrl = "http://127.0.0.1:4723";
        private WindowsDriver<WindowsElement> driver;

        private Dictionary<string, string> _windowHandles;
        private string _root = "MyDrawingForm";

        private string targetAppPath;


        [TestInitialize]
        public void Setup()
        {
            var projectName = "MyDrawingForm";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "MyDrawingForm.exe");
            Console.Write(targetAppPath);
            var appCapabilities = new AppiumOptions();
            appCapabilities.AddAdditionalCapability("app", targetAppPath);
            appCapabilities.AddAdditionalCapability("platformName", "Windows");
            appCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");

            driver = new WindowsDriver<WindowsElement>(new Uri(WinAppDriverUrl), appCapabilities);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _windowHandles = new Dictionary<string, string>
            {
                { _root, driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            driver.CloseApp();
            driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        [TestMethod]
        public void ToolStripButtons()
        {
            // Find and click the buttons
            WindowsElement start = driver.FindElementByName("Start");
            var terminator = driver.FindElementByName("Terminator");
            var process = driver.FindElementByName("Process");
            var decision = driver.FindElementByName("Decision");


            start.Click();
            terminator.Click();
            process.Click();
            decision.Click();
            //isStartChecked = start.GetAttribute("Toggle.ToggleState");
            //Assert.AreEqual("1", isStartChecked);
        }
        [TestMethod]
        public void TestDrawingArea()
        {
            // Find and click the drawing button
            var drawButton = driver.FindElementByName("Start");
            drawButton.Click();

            // Draw in the drawing area
            var drawingArea = driver.FindElementByName("DrawPanel");
            new Actions(driver)
                .MoveToElement(drawingArea, 10, 10)
                .ClickAndHold()
                .MoveByOffset(100, 100)
                .Release()
                .Perform();
        }

        [TestCleanup]
        public void TearDown()
        {
            CleanUp();
            driver.Quit();
        }
    }
}
