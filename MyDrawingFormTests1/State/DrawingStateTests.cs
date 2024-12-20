using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests1;
using System;
using System.Linq;
using System.Reflection;

namespace MyDrawingForm.Tests
{
    [TestClass]
    public class DrawingStateTests
    {
        Model _model;
        PointerState _pointerState;
        DrawingState _drawingState;
        PrivateObject _pState;

        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            _pointerState = new PointerState();
            _drawingState = new DrawingState(_pointerState);
            _drawingState.Initialize(_model);

            _pState = new PrivateObject(_drawingState);
        }

        [TestMethod]
        public void DrawingState_ConstructorTest()
        {
            // Test constructor
            Assert.IsNotNull(_drawingState);
        }

        [TestMethod]
        public void MouseDownTest()
        {
            int x = 10, y = 20;

            _model.SetDrawingMode("Start");
            _drawingState.MouseDown(-1, y);
            Assert.IsFalse((bool)_pState.GetField("_isPressed"));

            _model.SetDrawingMode("Start");
            _drawingState.MouseDown(x, -1);
            Assert.IsFalse((bool)_pState.GetField("_isPressed"));

            _model.SetDrawingMode("Start");
            _drawingState.MouseDown(x, y);

            var hintShape = _pState.GetField("_hint") as Shape;

            // Assert
            Assert.IsNotNull(hintShape);
            Assert.AreEqual(x, hintShape.X);
            Assert.AreEqual(y, hintShape.Y);
            Assert.AreEqual(true, _pState.GetField("_isPressed"));
            Assert.AreEqual(x, _pState.GetField("_firstPointX"));
            Assert.AreEqual(y, _pState.GetField("_firstPointY"));
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            // Arrange
            int startX = 10, startY = 20;
            int moveX = 30, moveY = 40;


            _drawingState.MouseMove(moveX, moveY);
            Assert.IsFalse((bool)_pState.GetField("_isPressed"));

            _model.SetDrawingMode("Start");
            _drawingState.MouseDown(startX, startY);

            // Act
            _drawingState.MouseMove(moveX, moveY);

            // Assert
            var hintShape = _pState.GetField("_hint") as Shape;
            Assert.IsNotNull(hintShape);
            Assert.AreEqual(moveX - startX, hintShape.Width);
            Assert.AreEqual(moveY - startY, hintShape.Height);

            _model.SetDrawingMode("Start");
            _drawingState.MouseDown(startX, startY);

            _drawingState.MouseMove(-moveX, -moveY);

            hintShape = _pState.GetField("_hint") as Shape;
            Assert.IsNotNull(hintShape);
            Assert.AreEqual(moveX + startX, hintShape.Width);
            Assert.AreEqual(moveY + startY, hintShape.Height);
        }

        [TestMethod]
        public void MouseUpTest()
        {
            // Arrange
            int startX = 10, startY = 20;
            int endX = 50, endY = 60;


            _model.SetDrawingMode("Start");
            _drawingState.MouseUp(0, 0);
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

        [TestMethod]
        public void OnPaintTest()
        {
            // Arrange
            IGraphics graphics = new MockGraphic();
            _model.SetDrawingMode("Start");

            _drawingState.MouseDown(10, 20);
            _drawingState.MouseMove(30, 40);

            _drawingState.OnPaint(graphics);

            _drawingState.MouseUp(30, 40);

            Shape shape1 = _model.GetShape("Start", "test", 0, 0, 10, 20);
            Shape shape2 = _model.GetShape("Start", "test", 0, 0, 10, 20);
            _model.AddShape(shape1);
            _model.AddShape(shape2);
            Line line = new Line(shape1, shape2, 1, 1);
            _model.AddLine(line);

            _drawingState.OnPaint(graphics);
        }

        [TestMethod]
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
