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
        Shape shape = new Process(1, "test", 10, 10, 100, 100);


        [TestMethod()]
        public void DrawTest()
        {
            IGraphics graphics = new MockGraphic();

            shape.Draw(graphics);
        }

        [TestMethod()]
        public void IsPointInShapeTest()
        {
            Assert.IsTrue(shape.IsPointInShape(60, 45));
            Assert.IsFalse(shape.IsPointInShape(5, 10));
        }

        [TestMethod()]
        public void IsPointAtTextTest()
        {
            Assert.IsTrue(shape.IsPointAtText(64, 40));
            Assert.IsFalse(shape.IsPointAtText(5, 10));
        }

        [TestMethod()]
        public void GetConnectorNumberTest()
        {
            Assert.AreEqual(1, shape.GetConnectorNumber(60, 10));
            Assert.AreEqual(2, shape.GetConnectorNumber(10, 60));
            Assert.AreEqual(3, shape.GetConnectorNumber(60, 110));
            Assert.AreEqual(4, shape.GetConnectorNumber(110, 60));
            Assert.AreEqual(-1, shape.GetConnectorNumber(0, 0));
        }
    }
}