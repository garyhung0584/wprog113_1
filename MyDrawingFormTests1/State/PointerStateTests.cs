using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingFormTests1;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class PointerStateTests
    {
        private Model _model;
        private PointerState _pointerState;
        private PrivateObject _pState;

        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            _pointerState = new PointerState();
            _pointerState.Initialize(_model);
            _pointerState._textChangeService = new MockService(_model);
            _pState = new PrivateObject(_pointerState);
        }

        [TestMethod()]
        public void InitializeTest()
        {
            _pointerState.Initialize(_model);

            Assert.AreEqual(_model, _pState.GetField("_m"));
            Assert.IsNull(_pointerState.selectedShape);
        }

        [TestMethod()]
        public void MouseDownTest()
        {
            Shape shape = _model.shapes.GetNewShape("Process", "test", 100, 100, 100, 100);
            _model.AddShape(shape);

            _pointerState.MouseDown(120, 125);

            Assert.IsTrue((bool)_pState.GetFieldOrProperty("_isPressed"));
            Assert.AreEqual(120, _pState.GetFieldOrProperty("_prevPointX"));
            Assert.AreEqual(125, _pState.GetFieldOrProperty("_prevPointY"));
            Assert.AreEqual(shape, _pointerState.selectedShape);

            _pointerState.MouseDown(15, 15);

            Assert.IsNull(_pointerState.selectedShape);


            _pointerState.MouseDown(152, 131);

            Assert.IsTrue((bool)_pState.GetFieldOrProperty("_isPressedOnce"));
            Assert.AreEqual(152, _pState.GetFieldOrProperty("_prevPointX"));
            Assert.AreEqual(131, _pState.GetFieldOrProperty("_prevPointY"));
            Assert.AreEqual(shape, _pointerState.selectedShape);

            _pointerState.MouseDown(152, 131);
            Assert.IsFalse((bool)_pState.GetFieldOrProperty("_isPressedOnce"));

        }

        [TestMethod()]
        public void MouseMoveTest()
        {

            Shape shape1 = _model.GetShape("Process", "test", 10, 10, 100, 100);
            _model.AddShape(shape1);
            _pointerState.MouseDown(9, 9);

            _pointerState.MouseMove(10, 10);

            _pointerState.MouseDown(50, 50);
            _pointerState.MouseMove(100, 100);
            Assert.AreEqual(100, _pState.GetFieldOrProperty("_prevPointX"));
            Assert.AreEqual(100, _pState.GetFieldOrProperty("_prevPointY"));

            _pointerState.MouseUp(10, 10);

            Assert.IsFalse((bool)_pState.GetFieldOrProperty("_isPressed"));

            _model.AddShape(_model.shapes.GetNewShape("Process", "test", 100, 100, 100, 100));
            _pointerState.MouseDown(152, 131);
            _pointerState.MouseMove(167, 139);

            Assert.IsTrue((bool)_pState.GetFieldOrProperty("_isDotPressed"));
            Assert.AreEqual(167, _pState.GetFieldOrProperty("_prevPointX"));
            Assert.AreEqual(139, _pState.GetFieldOrProperty("_prevPointY"));

        }

        [TestMethod()]
        public void MouseUpTest()
        {
            _model.AddShape(_model.shapes.GetNewShape("Process", "test", 0, 0, 10, 10));
            _pointerState.MouseDown(5, 5);

            _pointerState.MouseUp(5, 5);

            Shape shape1 = _model.GetShape("Process", "test", 10, 10, 100, 100);
            _model.AddShape(shape1);
            _pointerState.MouseDown(64, 40);
            _pointerState.MouseMove(100, 100);
            _pointerState.MouseUp(100, 100);

            Assert.IsFalse((bool)_pState.GetFieldOrProperty("_isPressed"));
        }

        [TestMethod()]
        public void OnPaintTest()
        {
            IGraphics graphics = new MockGraphic();
            Shape shape1 = _model.GetShape("Process", "test", 10, 10, 100, 100);
            Shape shape2 = _model.GetShape("Start", "test", 0, 0, 10, 20);
            _model.AddShape(shape1);
            _model.AddShape(shape2);
            Line line = new Line(shape1, shape2, 1, 1);
            _model.AddLine(line);

            _pointerState.OnPaint(graphics);

            _model.AddShape(_model.shapes.GetNewShape("Process", "test", 0, 0, 10, 10));
            _pointerState.MouseDown(5, 5);

            _pointerState.OnPaint(graphics);
        }
    }
}
