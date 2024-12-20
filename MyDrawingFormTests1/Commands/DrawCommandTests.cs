using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MyDrawingForm.Commands.Tests
{
    [TestClass()]
    public class DrawCommandTests
    {
        Model _model;
        Shape shape;

        DrawCommand drawCommand;

        [TestInitialize]
        public void TestInitialize()
        {
            _model = new Model();
            shape = _model.shapes.GetNewShape("Process", "test", 100, 100, 100, 100);
            
            drawCommand = new DrawCommand(_model, shape);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            drawCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);

        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            drawCommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
            drawCommand.UnExecute();
            Assert.AreEqual(0, _model.GetShapes().Count);
        }
    }
}