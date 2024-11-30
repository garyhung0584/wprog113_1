using MyDrawingForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingFormTests1
{
    class MockGraphic : IGraphics
    {

        public MockGraphic()
        {
        }

        public void ClearAll()
        {
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
        }

        public void DrawRectangle(float x, float y, float height, float width)
        {
        }

        public void DrawEllipse(float x, float y, float height, float width)
        {
        }

        public void DrawArc(float x, float y, float height, float width, float startAngle, float sweepAngle)
        {
        }

        public void DrawString(string text, float x, float y)
        {
        }

        public void DrawPolygon(float x, float y, float height, float width)
        {
        }

        public void DrawBoundingBox(float x, float y, float height, float width)
        {
        }

    }
}
