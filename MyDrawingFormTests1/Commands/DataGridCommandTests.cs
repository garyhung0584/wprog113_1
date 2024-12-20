using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm.Commands.Tests
{
    [TestClass()]
    public class DataGridCommandTests
    {
        Model _model;
        Shape shape, shape1, shape2;

        DataGridCommand dataGridCommand;

        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            shape = _model.GetShape("Process", "test", 100, 100, 100, 100);
            shape1 = _model.GetShape("Process", "test", 100, 100, 100, 100);
            shape2 = _model.GetShape("Process", "test", 100, 100, 100, 100);
            _model.AddShape(shape1);
            _model.AddShape(shape2);

            Line line = new Line(shape1, shape2, 1, 2);
            _model.AddLine(line);

            dataGridCommand = new DataGridCommand(_model, shape1);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            dataGridCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
            dataGridCommand.UnExecute();
            Assert.AreEqual(2, _model.GetShapes().Count);
            dataGridCommand = new DataGridCommand(_model, shape2);
            dataGridCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
            dataGridCommand.UnExecute();
            Assert.AreEqual(2, _model.GetShapes().Count);
            dataGridCommand = new DataGridCommand(_model, shape);
            dataGridCommand.Execute();
            Assert.AreEqual(2, _model.GetShapes().Count);
            dataGridCommand.UnExecute();
            Assert.AreEqual(3, _model.GetShapes().Count);

        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            dataGridCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
            dataGridCommand.UnExecute();
            Assert.AreEqual(2, _model.GetShapes().Count);
            dataGridCommand = new DataGridCommand(_model, shape2);
            dataGridCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
            dataGridCommand.UnExecute();
            Assert.AreEqual(2, _model.GetShapes().Count);
        }
    }
}