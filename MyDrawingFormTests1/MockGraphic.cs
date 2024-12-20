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

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
        }

        public void DrawRectangle(int x, int y, int height, int width)
        {
        }

        public void DrawEllipse(int x, int y, int height, int width)
        {
        }

        public void DrawArc(int x, int y, int height, int width, int startAngle, int sweepAngle)
        {
        }

        public void DrawString(string text, int x, int y)
        {
        }

        public void DrawPolygon(int x, int y, int height, int width)
        {
        }

        public void DrawBoundingBox(int x, int y, int height, int width)
        {
        }


        public void DrawDot(bool isRed, int x, int y, int height, int width)
        {
        }
    }
}
