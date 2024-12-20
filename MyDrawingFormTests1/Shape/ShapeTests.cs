using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests1;
using System;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        private Shape shape;
        private IGraphics graphics;

        [TestInitialize]
        public void Setup()
        {
            shape = new Process(0, "test", 0, 0, 10, 10);
            graphics = new MockGraphic();
        }

        [TestMethod()]
        public void DrawBoundingBoxTest()
        {
            shape.DrawBoundingBox(graphics);
        }

        [TestMethod()]
        public void DrawConnectorTest()
        {
            shape.DrawConnector(graphics);
        }


        [TestMethod()]
        public void NormalizeTest()
        {
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
