using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class ConnectorStateTests
    {
        Model _model;
        ConnectorState connectorState;
        PrivateObject _pState;

        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            connectorState = new ConnectorState();

            _pState = new PrivateObject(connectorState);
        }

        [TestMethod()]
        public void OnPaintTest()
        {
            IGraphics graphics = new MockGraphic();
            Shape shape1 = _model.GetShape("Process", "test", 10, 10, 100, 100);
            Shape shape2 = _model.GetShape("Start", "test", 0, 0, 10, 20);
            _model.AddShape(shape1);
            _model.AddShape(shape2);
            connectorState.Initialize(_model);
            Line line = new Line(shape1, shape2, 1, 1);
            _model.AddLine(line);
            connectorState.OnPaint(graphics);

            connectorState.MouseDown(60, 10);
            connectorState.MouseMove(60,60);

            connectorState.OnPaint(graphics);
        }

        [TestMethod()]
        public void MouseDownTest()
        {
            Shape shape = _model.GetShape("Process", "test", 10, 10, 100, 100);
            Shape shape1 = _model.GetShape("Process", "test", 200, 200, 100, 100);
            _model.AddShape(shape);
            _model.AddShape(shape1);
            connectorState.Initialize(_model);
            connectorState.MouseDown(60, 10);
            connectorState.MouseMove(100, 200);
            connectorState.MouseDown(201,248);
            connectorState.MouseDown(60, 10);
            connectorState.MouseDown(60, 10);
        }

        [TestMethod()]
        public void MouseMoveTest()
        {
            Shape shape = _model.GetShape("Process", "test", 10, 10, 100, 100);
            Shape shape1 = _model.GetShape("Process", "test", 200, 200, 100, 100);
            _model.AddShape(shape);
            _model.AddShape(shape1);
            connectorState.Initialize(_model);
            connectorState.MouseMove(60, 60);
            connectorState.MouseMove(-1, -1);
            connectorState.MouseDown(60, 10);
            connectorState.MouseMove(100, 200);
            //connectorState.MouseDown()
        }

        [TestMethod()]
        public void MouseUpTest()
        {
            connectorState.MouseUp(0, 0);
        }
    }
}