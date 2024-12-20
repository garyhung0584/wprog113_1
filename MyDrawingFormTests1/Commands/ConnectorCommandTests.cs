using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm.Commands;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static System.Windows.Forms.LinkLabel;

namespace MyDrawingForm.Commands.Tests
{
    [TestClass]
    public class ConnectorCommandTests
    {

        Model _model;
        Shape shape1, shape2;
        Line _line;

        ConnectorCommand command;

        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            shape1 = _model.GetShape("Process", "test", 100, 100, 100, 100);
            shape2 = _model.GetShape("Process", "test", 100, 100, 100, 100);
            _line = new Line(shape1, shape2, 1, 2);

            command = new ConnectorCommand(_model, _line);
        }

        [TestMethod]
        public void Execute_ShouldAddLineToModel()
        {
            command.Execute();

            Assert.AreEqual(1, _model.GetLines().Count);
            Assert.AreEqual(_line, _model.GetLines()[0]);
        }

        [TestMethod]
        public void UnExecute_ShouldRemoveLineFromModel()
        {
            command.Execute();
            Assert.AreEqual(1, _model.GetLines().Count);
            Assert.AreEqual(_line, _model.GetLines()[0]);

            command.UnExecute();

            Assert.AreEqual(0, _model.GetLines().Count);
        }
    }
}
