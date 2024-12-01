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
    public class ProcessTests
    {
        [TestMethod()]
        public void ProcessTest()
        {
            Shape shape = new Process(0, "test", 0, 0, 10, 10);
            Assert.AreEqual(0, shape.ShapeId);
            Assert.AreEqual("test", shape.ShapeText);
            Assert.AreEqual(0, shape.X);
            Assert.AreEqual(0, shape.Y);
            Assert.AreEqual(10, shape.Height);
            Assert.AreEqual(10, shape.Width);
        }

        [TestMethod()]
        public void DrawTest()
        {
            IGraphics graphics = new MockGraphic();
            Shape shape = new Process(0, "test", 0, 0, 10, 10);
            shape.Draw(graphics);
            shape = new Process(0, "test", 0, 0, -10, -10);
            shape.Draw(graphics);
        }

        [TestMethod()]
        public void IsPointInShapeTest()
        {
            Shape shape = new Process(0, "test", 0, 0, 10, 10);
            Assert.AreEqual(true, shape.IsPointInShape(5, 5));
            Assert.AreEqual(false, shape.IsPointInShape(100, 100));
        }
    }
}