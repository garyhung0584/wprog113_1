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
    public class ShapeTests
    {
        [TestMethod()]
        public void DrawBoundingBoxTest()
        {
            Shape shape = new Process(0, "test", 0, 0, 10, 10);
            IGraphics graphics = new MockGraphic();
            shape.DrawBoundingBox(graphics);
        }

        [TestMethod()]
        public void NormalizeTest()
        {
            Shape shape = new Process(0, "test", 0, 0, 10, 10);
            shape.Normalize();
            Assert.AreEqual(0, shape.X);
            Assert.AreEqual(0, shape.Y);
            Assert.AreEqual(10, shape.Height);
            Assert.AreEqual(10, shape.Width);

            shape = new Process(0, "test", 0, 0, -10, -10);
            shape.Normalize();
            Assert.AreEqual(-10, shape.X);
            Assert.AreEqual(-10, shape.Y);
            Assert.AreEqual(10, shape.Height);
            Assert.AreEqual(10, shape.Width);
        }
    }
}