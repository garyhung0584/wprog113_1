using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Shape shape1 = factory.Create("wrongInput", 0, "test", 0, 0, 10, 10);

            Assert.AreEqual(null, shape1);

        }
    }
}