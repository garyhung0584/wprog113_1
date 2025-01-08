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
using MainFormUITest;

namespace MyDrawingFormUITest
{

    [TestClass]
    public class MyDrawingFormUITest
    {

        private Robot _robot;
        private string _root = "MyDrawingForm";
        private string targetAppPath;


        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "MyDrawingForm";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "MyDrawingForm.exe");
            _robot = new Robot(targetAppPath, _root);
        }

        [TestMethod]
        public void ToolStrip()
        {
            //ToolStripButtons();

            DrawingShapes();
            MoveShapeTest();
        }

        public void ToolStripButtons()
        {
            _robot.ClickButton("Start");
            _robot.AssertEnable("Start", true);
            //_robot.AssertCheck("Start", "1");
            _robot.ClickButton("Terminator");
            _robot.ClickButton("Process");
            _robot.ClickButton("Decision");

            _robot.AssertEnable("Start", true);
            _robot.AssertEnable("Start", true);

            //isStartChecked = start.GetAttribute("Toggle.ToggleState");
            //Assert.AreEqual("1", isStartChecked);
        }
        public void DrawingShapes()
        {

            _robot.ClickButton("Start");
            _robot.PanelDrag("DrawPanel", 10, 10, 100, 100);
            UndoRedoTest();
            //var state = new string[] { "Start", "0", "test", "10", "10", "100", "100" };
            //_robot.AssertDataGridViewRowData("DataGridView", 0, state);

            _robot.ClickButton("Terminator");
            _robot.PanelDrag("DrawPanel", 110, 110, 150, 100);
            UndoRedoTest();

            _robot.ClickButton("Process");
            _robot.PanelDrag("DrawPanel", 210, 210, 100, 100);
            UndoRedoTest();

            _robot.ClickButton("Decision");
            _robot.PanelDrag("DrawPanel", 310, 310, 100, 100);
            UndoRedoTest();

            _robot.ClickButton("toolStripConnectorButton");
            _robot.ClickAt("DrawPanel", 110, 60);
            _robot.ClickAt("DrawPanel", 185, 110);
            UndoRedoTest();
        }

        public void MoveShapeTest()
        {

            _robot.PanelDrag("DrawPanel", 55, 55, 200, 0);
            UndoRedoTest();
            _robot.PanelDrag("DrawPanel", 255, 55, -200, 0);
        }


        public void UndoRedoTest()
        {
            //_robot.ClickButton("toolStripUndoButton");
            //_robot.AssertEnable("toolStripRedoButton", true);
            //_robot.ClickButton("toolStripRedoButton");
            //_robot.AssertEnable("toolStripUndoButton", true);
            //_robot.AssertEnable("toolStripRedoButton", false);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

    }
}
