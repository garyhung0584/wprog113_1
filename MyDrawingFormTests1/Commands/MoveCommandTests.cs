using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm.Commands;

namespace MyDrawingForm.Commands.Tests
{
    [TestClass]
    public class MoveCommandTests
    {
        private class TestShape : Shape
        {
            public TestShape(string name, int id, string text, int x, int y, int width, int height, int textBiasX = 0, int textBiasY = 0)
                : base(name, id, text, x, y, width, height, textBiasX, textBiasY)
            {
            }

            public override void Draw(IGraphics graphics) { }
            public override bool IsPointInShape(int x, int y) => false;
            public override bool IsPointAtText(int x, int y) => false;
            public override int GetConnectorNumber(int x, int y) => 0;
        }

        [TestMethod]
        public void Execute_ShouldMoveShapeToNewPosition()
        {
            // Arrange
            var shape = new TestShape("TestShape", 1, "Test", 0, 0, 100, 100);
            var command = new MoveCommand(shape, shape.X, shape.Y);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(0, shape.X);
            Assert.AreEqual(0, shape.Y);
        }

        [TestMethod]
        public void UnExecute_ShouldMoveShapeBackToOriginalPosition()
        {
            // Arrange
            var shape = new TestShape("TestShape", 1, "Test", 0, 0, 100, 100);
            var command = new MoveCommand(shape, 5, 15);

            // Act
            command.Execute();
            command.UnExecute();

            // Assert
            Assert.AreEqual(5, shape.X);
            Assert.AreEqual(15, shape.Y);
        }
    }
}
