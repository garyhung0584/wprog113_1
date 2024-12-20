using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm.Commands;

namespace MyDrawingForm.Commands.Tests
{
    [TestClass]
    public class TextMoveCommandTests
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
        public void Execute_ShouldMoveTextToNewPosition()
        {
            // Arrange
            var shape = new TestShape("TestShape", 1, "Test", 0, 0, 100, 100, 10, 20);
            var command = new TextMoveCommand(shape, shape.TextBiasX, shape.TextBiasY);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(10, shape.TextBiasX);
            Assert.AreEqual(20, shape.TextBiasY);
        }

        [TestMethod]
        public void UnExecute_ShouldMoveTextBackToOriginalPosition()
        {
            // Arrange
            var shape = new TestShape("TestShape", 1, "Test", 0, 0, 100, 100, 10, 20);
            var command = new TextMoveCommand(shape, 5, 15);

            // Act
            command.Execute();
            command.UnExecute();

            // Assert
            Assert.AreEqual(5, shape.TextBiasX);
            Assert.AreEqual(15, shape.TextBiasY);
        }
    }
}
