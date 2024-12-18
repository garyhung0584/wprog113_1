using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using System;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class ShapeFactoryTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            ShapeFactory factory = new ShapeFactory();
            Shape shape = factory.Create("Start", 0, "test", 0, 0, 10, 10);
            Assert.AreEqual(0, shape.ShapeId);
            Assert.AreEqual("Start", shape.ShapeName);
            Assert.AreEqual("test", shape.ShapeText);
            Assert.AreEqual(0, shape.X);
            Assert.AreEqual(0, shape.Y);
            Assert.AreEqual(10, shape.Width);
            Assert.AreEqual(10, shape.Height);

            Shape shape1 = factory.Create("wrongInput", 0, "test", 0, 0, 10, 10);
            Assert.IsNull(shape1);
        }
    }
}
