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
        public void Tests()
        {
            ToolStripButtonsTest();
            DrawShapeTest();
            MoveShapeTest();
            RemoveShapeTest();
            AssertShapeTest();
            EditShapeTest();
            MoveTextTest();
        }

        public void ToolStripButtonsTest()
        {
            _robot.ClickButton("Start");
            _robot.AssertEnable("Start", true);
            //_robot.AssertCheck("Start", "1");
            _robot.ClickButton("Terminator");
            _robot.ClickButton("Process");
            _robot.ClickButton("Decision");
            _robot.ClickButton("toolStripConnectorButton");
            _robot.ClickButton("toolStripSelectButton");


            _robot.AssertEnable("Start", true);
            _robot.AssertEnable("Start", true);

            //isStartChecked = start.GetAttribute("Toggle.ToggleState");
            //Assert.AreEqual("1", isStartChecked);
        }
        public void DrawShapeTest()
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


        public void AssertShapeTest()
        {
            // Start
            _robot.AssertEnable("addShape", false);
            _robot.InputText("nameTextBox", "test");
            _robot.InputText("xTextBox", "10");
            _robot.InputText("yTextBox", "10");
            _robot.InputText("widthTextBox", "100");
            _robot.InputText("heightTextBox", "100");
            _robot.SelectComboBox("shapeAddComboBox", "Start");
            _robot.AssertEnable("addShape", true);
            _robot.ClickButton("addShape");

            // Terminator
            _robot.InputText("nameTextBox", "Terminator");
            _robot.InputText("xTextBox", "110");
            _robot.InputText("yTextBox", "110");
            _robot.InputText("widthTextBox", "100");
            _robot.InputText("heightTextBox", "150");
            _robot.SelectComboBox("shapeAddComboBox", "Terminator");
            _robot.AssertEnable("addShape", true);
            _robot.ClickButton("addShape");

            // Process
            _robot.InputText("nameTextBox", "Process");
            _robot.InputText("xTextBox", "210");
            _robot.InputText("yTextBox", "210");
            _robot.InputText("widthTextBox", "100");
            _robot.InputText("heightTextBox", "100");
            _robot.SelectComboBox("shapeAddComboBox", "Process");
            _robot.AssertEnable("addShape", true);
            _robot.ClickButton("addShape");

            // Decision
            _robot.InputText("nameTextBox", "Decision");
            _robot.InputText("xTextBox", "310");
            _robot.InputText("yTextBox", "310");
            _robot.InputText("widthTextBox", "100");
            _robot.InputText("heightTextBox", "100");
            _robot.SelectComboBox("shapeAddComboBox", "Decision");
            _robot.AssertEnable("addShape", true);
            _robot.ClickButton("addShape");

            // Assert
            var state = new string[] { "Start", "0", "test", "10", "10", "100", "100" };
            _robot.AssertDataGridViewRowData("DataGridView", 0, state);

            state = ["Terminator", "1", "test", "110", "110", "100", "150"];
            _robot.AssertDataGridViewRowData("DataGridView", 1, state);
            
            state = ["Process", "2", "test", "210", "210", "100", "100"];
            _robot.AssertDataGridViewRowData("DataGridView", 2, state);
            
            state = ["Decision", "3", "test", "310", "310", "100", "100"];
            _robot.AssertDataGridViewRowData("DataGridView", 3, state);
        }

        public void RemoveShapeTest()
        {
            for (int i = 3; i >= 0; i--)
            {
                _robot.ClickRemoveDataGridViewRow("DataGridView", i);
            }
            UndoRedoTest();
        }

        public void EditShapeTest()
        {
            _robot.ClickAt("DrawPanel", 65, 40);
            _robot.ClickAt("DrawPanel", 65, 40);

            _robot.AssertEnable("buttonConfirm", false);
            _robot.InputText("textBox1", "t");
            _robot.AssertEnable("buttonConfirm", true);
            _robot.InputText("textBox1", "");
            _robot.AssertEnable("buttonConfirm", false);
            _robot.InputText("textBox1", "tesd");
            _robot.ClickButton("buttonConfirm");
        }
        public void MoveTextTest()
        {
            _robot.PanelDrag("DrawPanel", 65, 40, 0, 30);
        }


        public void UndoRedoTest()
        {
            _robot.ClickButton("toolStripUndoButton");
            _robot.AssertEnable("toolStripRedoButton", true);
            _robot.ClickButton("toolStripRedoButton");
            _robot.AssertEnable("toolStripUndoButton", true);
            _robot.AssertEnable("toolStripRedoButton", false);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

    }
}
