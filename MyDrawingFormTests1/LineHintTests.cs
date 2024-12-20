using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests1;

namespace MyDrawingForm.Tests
{
    [TestClass]
    public class LineHintTests
    {
        [TestMethod]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            int x = 10, y = 20, x2 = 30, y2 = 40;

            // Act
            var lineHint = new LineHint(x, y, x2, y2);

            // Assert
            Assert.AreEqual(x, lineHint.X);
            Assert.AreEqual(y, lineHint.Y);
            Assert.AreEqual(x2, lineHint.X2);
            Assert.AreEqual(y2, lineHint.Y2);
        }

        [TestMethod]
        public void DrawHint_ShouldCallDrawLineOnGraphics()
        {
            // Arrange
            var mockGraphics = new MockGraphic();
            var lineHint = new LineHint(10, 20, 30, 40);

            // Act
            lineHint.DrawHint(mockGraphics);
        }
    }
}
