using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class PointerStateTests
    {
        Model _model;
        PointerState _pointerState;

        PrivateObject pState;

        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            _pointerState = new PointerState();
            _pointerState.Initialize(_model);

            pState = new PrivateObject(_pointerState);
        }


        [TestMethod()]
        public void InitializeTest()
        {
            _pointerState.Initialize(_model);

            Assert.AreEqual(_model, pState.GetField("_m"));
            Assert.AreEqual(0, _pointerState.selectedShapes.Count);
            Assert.AreEqual(false, pState.GetField("_isCtrlKeyDown"));
        }

        [TestMethod()]
        public void MouseDownTest()
        {
            _model.AddShape("Process", "test", 0, 0, 10, 10);
            _model.AddShape("Process", "test", 100, 100, 10, 10);

            _pointerState.MouseDown(5, 5);
            _pointerState.MouseDown(5, 5);
            Assert.AreEqual(pState.GetFieldOrProperty("_isPressed"), true);
            Assert.AreEqual(pState.GetFieldOrProperty("_prevPointX"), 5f);
            Assert.AreEqual(pState.GetFieldOrProperty("_prevPointY"), 5f);

            _pointerState.MouseDown(5, 5);
            Assert.AreEqual(_pointerState.selectedShapes.Count(), 1);

            _pointerState.MouseDown(15, 15);
            Assert.AreEqual(_pointerState.selectedShapes.Count(), 0);

            _pointerState.KeyDown(17);
            Assert.IsTrue((bool)pState.GetFieldOrProperty("_isCtrlKeyDown"));
            _pointerState.MouseDown(5, 5);
            Assert.AreEqual(_pointerState.selectedShapes.Count(), 1);
            _pointerState.MouseDown(5, 5);
            Assert.AreEqual(_pointerState.selectedShapes.Count(), 0);

            _pointerState.MouseDown(5, 5);
            _pointerState.MouseDown(105, 105);
            Assert.AreEqual(_pointerState.selectedShapes.Count(), 2);

            _pointerState.MouseDown(15, 15);
            Assert.AreEqual(_pointerState.selectedShapes.Count(), 2);

            _pointerState.KeyUp(17);
            _model.AddShape("Process", "test", 100, 100, 100, 100);
            _pointerState.MouseDown(162, 134);
            _pointerState.MouseDown(162, 134);
            Assert.IsTrue((bool)pState.GetFieldOrProperty("_isDotPressed"));
        }

        [TestMethod()]
        public void AddSelectedShapeTest()
        {
            _pointerState.selectedShapes.Clear();

            Shape shape =  _model.shapes.GetNewShape("Process", "test", 0, 0, 10, 10);
            _pointerState.AddSelectedShape(shape);
            
            Assert.AreEqual(_pointerState.selectedShapes.Count(), 1);
            
            _pointerState.AddSelectedShape(shape);
            Assert.AreEqual(_pointerState.selectedShapes.Count(), 1);

        }

        [TestMethod()]
        public void MouseMoveTest()
        {
            _pointerState.selectedShapes.Clear();

            _model.AddShape("Process", "test", 0, 0, 10, 10);
            _pointerState.MouseMove(5, 5);
            Assert.AreEqual(false, pState.GetFieldOrProperty("_isPressed"));

            _pointerState.MouseDown(5, 5);
            _pointerState.MouseDown(5, 5);
            Assert.AreEqual(true, pState.GetFieldOrProperty("_isPressed"));
            _pointerState.MouseMove(10f, 10f);
            Assert.AreEqual(10f, pState.GetFieldOrProperty("_prevPointX"));
            Assert.AreEqual(10f, pState.GetFieldOrProperty("_prevPointY"));

            _pointerState.MouseUp(0, 0);
            _model.AddShape("Process", "test", 100, 100, 100, 100);
            _pointerState.MouseDown(162, 134);
            _pointerState.MouseDown(162, 134);
            _pointerState.MouseMove(167, 139);
            Assert.IsTrue((bool)pState.GetFieldOrProperty("_isDotPressed"));
            Assert.AreEqual(167f, pState.GetFieldOrProperty("_prevPointX"));
            Assert.AreEqual(139f, pState.GetFieldOrProperty("_prevPointY"));
        }

        [TestMethod()]
        public void MouseUpTest()
        {
            _model.AddShape("Process", "test", 0, 0, 10, 10);
            _pointerState.MouseDown(5, 5);
            _pointerState.MouseDown(5, 5);
            Assert.IsTrue((bool)pState.GetFieldOrProperty("_isPressed"));
            _pointerState.MouseUp(5, 5);
            Assert.IsFalse((bool)pState.GetFieldOrProperty("_isPressed"));
        }

        [TestMethod()]
        public void OnPaintTest()
        {
            IGraphics graphics = new MockGraphic();

            _model.AddShape("Start", "test", 10, 20, 20, 20);
            _model.AddShape("Terminator", "test", 10, 20, 20, 20);

            _pointerState.OnPaint(graphics);

            _model.AddShape("Process", "test", 0, 0, 10, 10);
            _pointerState.MouseDown(5, 5);

            _pointerState.OnPaint(graphics);
        }

        [TestMethod()]
        public void KeyDownTest()
        {
            _pointerState.KeyDown(18);
            Assert.IsFalse((bool)pState.GetFieldOrProperty("_isCtrlKeyDown"));
            _pointerState.KeyDown(17);
            Assert.IsTrue((bool)pState.GetFieldOrProperty("_isCtrlKeyDown"));
        }

        [TestMethod()]
        public void KeyUpTest()
        {
            _pointerState.KeyDown(17);
            Assert.IsTrue((bool)pState.GetFieldOrProperty("_isCtrlKeyDown"));
            _pointerState.KeyUp(18);
            Assert.IsTrue((bool)pState.GetFieldOrProperty("_isCtrlKeyDown"));
            _pointerState.KeyUp(17);
            Assert.IsFalse((bool)pState.GetFieldOrProperty("_isCtrlKeyDown"));
        }
    }
}