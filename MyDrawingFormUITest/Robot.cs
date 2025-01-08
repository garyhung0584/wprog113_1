using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Windows.Input;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace MainFormUITest
{
    public class Robot
    {
        private WindowsDriver<WindowsElement> _driver;
        private Dictionary<string, string> _windowHandles;
        private string _root;
        private const string CONTROL_NOT_FOUND_EXCEPTION = "The specific control is not found!!";
        private const string WIN_APP_DRIVER_URI = "http://127.0.0.1:4723";

        // constructor
        public Robot(string targetAppPath, string root)
        {
            this.Initialize(targetAppPath, root);
        }

        // initialize
        public void Initialize(string targetAppPath, string root)
        {
            _root = root;
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", targetAppPath);
            options.AddAdditionalCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri(WIN_APP_DRIVER_URI), options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _windowHandles = new Dictionary<string, string>
            {
                { _root, _driver.CurrentWindowHandle }
            };
        }

        // clean up
        public void CleanUp()
        {
            SwitchTo(_root);
            _driver.CloseApp();
            _driver.Dispose();
        }

        // test
        public void SwitchTo(string formName)
        {
            if (_windowHandles.ContainsKey(formName))
            {
                _driver.SwitchTo().Window(_windowHandles[formName]);
            }
            else
            {
                foreach (var windowHandle in _driver.WindowHandles)
                {
                    _driver.SwitchTo().Window(windowHandle);
                    try
                    {
                        _driver.FindElementByAccessibilityId(formName);
                        _windowHandles.Add(formName, windowHandle);
                        return;
                    }
                    catch
                    {

                    }
                }
            }
        }

        // test
        public void ClickButton(string name)
        {
            _driver.FindElementByName(name).Click();
        }

        // test
        public void AssertEnable(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Enabled);
        }

        //test
        public void AssertSelected(string name, bool state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.Selected);
        }

        public void AssertCheck(string name, string state)
        {
            WindowsElement element = _driver.FindElementByName(name);
            Assert.AreEqual(state, element.GetAttribute("Toggle.ToggleState"));
        }

        public void PanelDrag(string panel, int startX, int startY, int offsetX, int offsetY)
        {
            // Draw in the drawing area
            var drawingArea = _driver.FindElementByName(panel);
            new Actions(_driver)
                .MoveToElement(drawingArea, startX, startY)
                .ClickAndHold()
                .MoveByOffset(offsetX, offsetY)
                .Release()
                .Perform();
        }

        public void ClickAt(string name, int x, int y)
        {
            WindowsElement element = _driver.FindElementByName(name);
            new Actions(_driver)
                .MoveToElement(element, x, y)
                .Click()
                .Perform();
        }

        // test
        public void AssertDataGridViewRowData(string name, int rowIndex, string[] data)
        {
            var dataGridView = _driver.FindElementByName(name);
            var rowDatas = dataGridView.FindElementByName($"Row {rowIndex}").FindElementsByXPath("//*");

            // FindElementsByXPath("//*") 會把 "row" node 也抓出來，因此 i 要從 1 開始以跳過 "row" node
            for (int i = 3; i < rowDatas.Count; i++)
            {
                //Assert.AreEqual(data[i - 1], rowDatas[i].Text.Replace("(null)", ""));
                if (i == 5)
                {

                }
                else Assert.AreEqual(data[i - 3], rowDatas[i].Text.Replace("(null)", ""));
            }
        }
    }
}
