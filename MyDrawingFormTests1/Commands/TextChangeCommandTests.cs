using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm.Commands.Tests
{
    [TestClass()]
    public class TextChangeCommandTests
    {
        Model _model;
        Shape shape;
        string text;

        TextChangeCommand command;

        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            shape = _model.shapes.GetNewShape("Process", "test", 100, 100, 100, 100);
            text  = "testnew";
            command = new TextChangeCommand(shape, text);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            command.Execute();
            Assert.AreEqual(text, shape.ShapeText);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            command.Execute();
            Assert.AreEqual(text, shape.ShapeText);
            command.UnExecute();
            Assert.AreEqual("test", shape.ShapeText);
        }
    }
}