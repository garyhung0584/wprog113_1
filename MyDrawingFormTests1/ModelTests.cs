using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests1;

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

            Assert.AreEqual("", model.GetDrawingMode());
        }

        [TestMethod()]
        public void EnterDrawingStateTest()
        {
            model.SetDrawingMode("Start");

            Assert.AreEqual("Start", model.GetDrawingMode());
        }

        [TestMethod()]
        public void EnterConnectorStateTest()
        {
            model.SetConnectorMode();

            Assert.AreEqual("", model.GetDrawingMode());

            Shape shape = model.GetShape("Start", "test", 0, 0, 10, 20);
            model.AddShape(shape);
            model.AddShape(shape);

            model.SetConnectorMode();
            Assert.AreEqual("Connector", model.GetDrawingMode());
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            // Act
            model.AddShape(model.GetShape("Start", "test", 0, 0, 10, 20));

            var shapes = model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("", model.GetDrawingMode());

            model.AddShape(model.GetShape("Terminator", "test", 0, 0, 10, 20));

            shapes = model.GetShapes();
            Assert.AreEqual(2, shapes.Count);
        }

        [TestMethod()]
        public void RemoveShapeTest()
        {
            Shape shape = model.GetShape("Start", "test", 0, 0, 10, 20);
            model.AddShape(shape);

            var shapes = model.GetShapes();
            Assert.AreEqual(1, shapes.Count);

            model.RemoveShape(shape);

            shapes = model.GetShapes();
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod()]
        public void DataGridRemoveShapeTest()
        {
            Shape shape = model.GetShape("Start", "test", 0, 0, 10, 20);
            model.AddShape(shape);

            var shapes = model.GetShapes();
            Assert.AreEqual(1, shapes.Count);

            model.DataGridRemoveShape(shape);

            shapes = model.GetShapes();
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod()]
        public void GetShapeTest()
        {
            Shape shape = model.GetShape("Start", "test", 0, 0, 10, 20);
            Assert.AreEqual("Start", shape.ShapeName);
            Assert.AreEqual("test", shape.ShapeText);
            Assert.AreEqual(0, shape.X);
            Assert.AreEqual(0, shape.Y);
            Assert.AreEqual(10, shape.Width);
            Assert.AreEqual(20, shape.Height);
        }

        [TestMethod()]
        public void GetLinesTest()
        {
            Shape shape1 = model.GetShape("Start", "test", 0, 0, 10, 20);
            Shape shape2 = model.GetShape("Start", "test", 0, 0, 10, 20);
            model.AddShape(shape1);
            model.AddShape(shape2);
            Line line = new Line(shape1, shape2, 1, 1);
            model.AddLine(line);
            var lines = model.GetLines();
            Assert.AreEqual(1, lines.Count);
        }

        [TestMethod()]
        public void AddLineTest()
        {
            Shape shape1 = model.GetShape("Start", "test", 0, 0, 10, 20);
            Shape shape2 = model.GetShape("Start", "test", 0, 0, 10, 20);
            model.AddShape(shape1);
            model.AddShape(shape2);
            Line line = new Line(shape1, shape2, 1, 1);
            model.AddLine(line);
            var lines = model.GetLines();
            Assert.AreEqual(1, lines.Count);
        }

        [TestMethod()]
        public void RemoveLineTest()
        {
            Shape shape1 = model.GetShape("Start", "test", 0, 0, 10, 20);
            Shape shape2 = model.GetShape("Start", "test", 0, 0, 10, 20);
            model.AddShape(shape1);
            model.AddShape(shape2);
            Line line = new Line(shape1, shape2, 1, 1);
            model.AddLine(line);
            var lines = model.GetLines();
            Assert.AreEqual(1, lines.Count);
            model.RemoveLine(line);
            Assert.AreEqual(0, lines.Count);
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
            IState mockState = new MockState();
            mockState.Initialize(model);
            model.currentState = mockState;

            model.PointerReleased(5, 6);

            MockState state = (MockState)model.currentState;

            Assert.AreEqual(state.mouseUpPosX, 5);
            Assert.AreEqual(state.mouseUpPosY, 6);
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
            model.SetDrawingMode("Start");

            Assert.AreEqual("Start", model.GetDrawingMode());
        }

        [TestMethod()]
        public void SetSelectModeTest()
        {
            model.SetSelectMode();

            Assert.AreEqual("", model.GetDrawingMode());
        }

        [TestMethod()]
        public void SetConnectorModeTest()
        {
            model.SetConnectorMode();

            Assert.AreEqual("", model.GetDrawingMode());

            Shape shape = model.GetShape("Start", "test", 0, 0, 10, 20);
            model.AddShape(shape);
            model.AddShape(shape);
            model.SetConnectorMode();
            Assert.AreEqual("Connector", model.GetDrawingMode());
        }

        [TestMethod()]
        public void UndoTest()
        {
            Shape shape = model.GetShape("Start", "test", 0, 0, 10, 20);
            model.AddShape(shape);
            Assert.AreEqual(1, model.GetShapes().Count);
            model.DataGridRemoveShape(shape);
            Assert.AreEqual(0, model.GetShapes().Count);
            model.Undo();
            Assert.AreEqual(1, model.GetShapes().Count);
            model.Redo();
            Assert.AreEqual(0, model.GetShapes().Count);
        }

        [TestMethod()]
        public void RedoTest()
        {
            Shape shape = model.GetShape("Start", "test", 0, 0, 10, 20);
            model.AddShape(shape);
            Assert.AreEqual(1, model.GetShapes().Count);
            model.DataGridRemoveShape(shape);
            Assert.AreEqual(0, model.GetShapes().Count);
            model.Undo();
            Assert.AreEqual(1, model.GetShapes().Count);
            model.Redo();
            Assert.AreEqual(0, model.GetShapes().Count);
        }

        [TestMethod()]
        public void GetDrawingModeTest()
        {
            model.SetDrawingMode("Start");

            Assert.AreEqual("Start", model.GetDrawingMode());
        }

        [TestMethod()]
        public void GetShapesTest()
        {
            model.AddShape(model.GetShape("Terminator", "test", 0, 0, 10, 20));

            Assert.AreEqual(1, model.GetShapes().Count);
        }

        [TestMethod()]
        public void NotifyModelChangedTest()
        {
            bool isNotified = false;
            model.ModelChanged += () => { isNotified = true; };

            model.NotifyModelChanged();

            Assert.IsTrue(isNotified);
        }
    }
}