using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class ModelTests
    {

        public Model model;

        [TestInitialize]
        public void Setup()
        {
            this.model = new Model();
        }

        [TestMethod()]
        public void EnterPointerStateTest()
        {
            model.EnterPointerState();

            // Assert
            Assert.AreEqual("", model.GetDrawingMode());
        }

        [TestMethod()]
        public void EnterDrawingStateTest()
        {

            // Act
            model.SetDrawingMode("Start");

            // Assert
            Assert.AreEqual("Start", model.GetDrawingMode());
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            // Arrange
            Model model = new Model();

            // Act
            model.AddShape("Start", "test", 0, 0, 10, 20);

            // Assert
            var shapes = model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("", model.GetDrawingMode());

            model.AddShape("Terminator", "test", 0, 0, 10, 20);

            shapes = model.GetShapes();
            Assert.AreEqual(2, shapes.Count);

            model.AddShape("Process", "test", 0, 0, 10, 20);

            shapes = model.GetShapes();
            Assert.AreEqual(3, shapes.Count);

            model.AddShape("Decision", "test", 0, 0, 10, 20);

            shapes = model.GetShapes();
            Assert.AreEqual(4, shapes.Count);
        }


        [TestMethod()]
        public void PointerPressedTest()
        {

            IState mockState = new MockState();
            mockState.Initialize(model);
            model.currentState = mockState;

            model.PointerPressed(1, 2);
            MockState state = (MockState)model.currentState;

            Assert.AreEqual(state.mouseDownPosX, 1);
            Assert.AreEqual(state.mouseDownPosY, 2);
        }

        [TestMethod()]
        public void PointerMovedTest()
        {
            IState mockState = new MockState();
            mockState.Initialize(model);
            model.currentState = mockState;

            model.PointerMoved(3, 4);

            MockState state = (MockState)model.currentState;

            Assert.AreEqual(state.mouseMovePosX, 3);
            Assert.AreEqual(state.mouseMovePosY, 4);

        }

        [TestMethod()]
        public void PointerReleasedTest()
        {
            // Arrange
            Model model = new Model();
            IState mockState = new MockState();
            mockState.Initialize(model);
            model.currentState = mockState;

            model.PointerReleased(5, 6);

            MockState state = (MockState)model.currentState;

            Assert.AreEqual(state.mouseUpPosX, 5);
            Assert.AreEqual(state.mouseUpPosY, 6);

        }

        [TestMethod()]
        public void KeyDownTest()
        {
            IState mockState = new MockState();
            mockState.Initialize(model);
            model.currentState = mockState;

            model.KeyDown(17);

            MockState state = (MockState)model.currentState;

            Assert.AreEqual(state.keyDownValue, 17);

        }

        [TestMethod()]
        public void KeyUpTest()
        {
            IState mockState = new MockState();
            mockState.Initialize(model);
            model.currentState = mockState;

            model.KeyUp(18);

            MockState state = (MockState)model.currentState;

            Assert.AreEqual(state.keyUpValue, 18);

        }

        [TestMethod()]
        public void DrawTest()
        {
            IState mockState = new MockState();
            mockState.Initialize(model);
            model.currentState = mockState;
            IGraphics graphics = new MockGraphic();

            model.Draw(graphics);


            MockState state = (MockState)model.currentState;

            Assert.IsTrue(state.isOnPaintCalled);
        }

        [TestMethod()]
        public void SetDrawingModeTest()
        {

            // Act
            model.SetDrawingMode("Start");

            // Assert
            Assert.AreEqual("Start", model.GetDrawingMode());
        }

        [TestMethod()]
        public void SetSelectModeTest()
        {

            // Act
            model.SetSelectMode();

            // Assert
            Assert.AreEqual("", model.GetDrawingMode());
        }

        [TestMethod()]
        public void GetDrawingModeTest()
        {

            // Act
            model.SetDrawingMode("Start");

            // Assert
            Assert.AreEqual("Start", model.GetDrawingMode());
        }

        [TestMethod()]
        public void GetShapesTest()
        {

            // Arrange
            Model model = new Model();

            // Act
            model.AddShape("Terminator", "test", 0, 0, 10, 20);

            // Assert
            Assert.AreEqual(1, model.GetShapes().Count());
        }

        [TestMethod()]
        public void NotifyModelChangedTest()
        {
            bool isNotified;
            model.ModelChanged += () => { isNotified = true; };
            isNotified = false;

            // Act
            model.NotifyModelChanged();

            Assert.IsTrue(isNotified);
        }
    }
}