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
    public class LineTests
    {
        Model _model = new Model();
        [TestMethod()]
        public void LineTest()
        {
            Shape shape1 = _model.GetShape("Start", "test", 0, 0, 10, 10);
            Shape shape2 = _model.GetShape("Process", "test", 0, 0, 10, 10);
            Line _line = new Line(shape1, shape2, 1, 2);
        }

        [TestMethod()]
        public void DrawTest()
        {
            Shape shape1 = _model.GetShape("Start", "test", 0, 0, 10, 10);
            Shape shape2 = _model.GetShape("Process", "test", 0, 0, 10, 10);
            Line _line = new Line(shape1, shape2, 1, 2);
            IGraphics graphics = new MockGraphic();
            _line.Draw(graphics);
            _line.P1 = 3;
            _line.P2 = 4;
            _line.Draw(graphics);
        }
    }
}