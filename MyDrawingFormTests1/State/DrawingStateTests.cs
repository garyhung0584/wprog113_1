using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests1;
using System;
using System.Linq;
using System.Reflection;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class DrawingStateTests
    {
        private Model _model;
        private PointerState _pointerState;
        private DrawingState _drawingState;

        PrivateObject pState;

        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            _pointerState = new PointerState();
            _drawingState = new DrawingState(_pointerState);
            _drawingState.Initialize(_model);

            pState = new PrivateObject(_drawingState);
        }

        [TestMethod()]
        public void DrawingStateTest()
        {
            // Test constructor
            Assert.IsNotNull(_drawingState);
        }


        [TestMethod()]
        public void MouseDownTest()
        {
            // Arrange
            float x = 10f, y = 20f;

            // Act
            _model.SetDrawingMode("Start");
            _drawingState.MouseDown(x, y);

            var hintShape = pState.GetField("_hint") as Shape;

            Assert.IsNotNull(hintShape);
            Assert.AreEqual(x, hintShape.X);
            Assert.AreEqual(y, hintShape.Y);
            Assert.AreEqual(pState.GetField("_isPressed"), true);
            Assert.AreEqual(pState.GetField("_firstPointX"), x);
            Assert.AreEqual(pState.GetField("_firstPointY"), y);


            x = -10f;
            y = -20f;
            _model.SetDrawingMode("Start");
            _drawingState.MouseDown(x, y);
            hintShape = pState.GetField("_hint") as Shape;
            Assert.IsNotNull(hintShape);
            Assert.AreEqual(x, hintShape.X);
            Assert.AreEqual(y, hintShape.Y);
        }

        [TestMethod()]
        public void MouseMoveTest()
        {
            // Arrange
            float startX = 10f, startY = 20f;
            float moveX = 30f, moveY = 40f;

            _model.SetDrawingMode("Start");
            _drawingState.MouseDown(startX, startY);

            // Act
            _drawingState.MouseMove(moveX, moveY);

            // Assert
            var hintShape = pState.GetField("_hint") as Shape;
            Assert.AreEqual(moveX - startX, hintShape.Width);
            Assert.AreEqual(moveY - startY, hintShape.Height);

            _drawingState.MouseUp(moveX, moveY);
            _drawingState.MouseMove(moveX, moveY);
            Assert.AreEqual(moveX - startX, hintShape.Width);
            Assert.AreEqual(moveY - startY, hintShape.Height);
        }

        [TestMethod()]
        public void MouseUpTest()
        {
            // Arrange
            float startX = 10f, startY = 20f;
            float endX = 50f, endY = 60f;

            _drawingState.MouseUp(endX, endY);
            _model.SetDrawingMode("Start");
            _drawingState.MouseDown(startX, startY);
            _drawingState.MouseMove(endX, endY);

            // Act
            _drawingState.MouseUp(endX, endY);

            // Assert
            var shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            var shape = shapes[0];
            Assert.AreEqual(startX, shape.X);
            Assert.AreEqual(startY, shape.Y);
            Assert.AreEqual(endX - startX, shape.Width);
            Assert.AreEqual(endY - startY, shape.Height);
        }

        [TestMethod()]
        public void OnPaintTest()
        {
            // Arrange

            IGraphics graphics = new MockGraphic();
            _model.SetDrawingMode("Start");
            _drawingState.MouseDown(10f, 20f);
            _drawingState.MouseMove(30f, 40f);
            _drawingState.OnPaint(graphics);
            _drawingState.MouseUp(50f, 60f);

            _model.AddShape("Start", "test", 10, 20, 20, 20);
            _model.AddShape("Terminator", "test", 10, 20, 20, 20);
            _model.AddShape("Process", "test", 10, 20, 20, 20);
            _model.AddShape("Decision", "test", 10, 20, 20, 20);

            // Act
            _drawingState.OnPaint(graphics);


        }

        [TestMethod()]
        public void KeyDownTest()
        {
            // Act
            _drawingState.KeyDown(0);

            // Assert
            // No state changes expected; just ensuring no exceptions occur
        }

        [TestMethod()]
        public void KeyUpTest()
        {
            // Act
            _drawingState.KeyUp(0);

            // Assert
            // No state changes expected; just ensuring no exceptions occur
        }

        [TestMethod()]
        public void GenerateRandomStringTest()
        {
            // Act
            var result = DrawingState.GenerateRandomString(10);

            // Assert
            Assert.AreEqual(10, result.Length);
            Assert.IsTrue(result.All(c => DrawingState.chars.Contains(c)));
        }
    }
}
