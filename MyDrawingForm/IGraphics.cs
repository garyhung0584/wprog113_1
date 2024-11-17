using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public interface IGraphics
    {
        void ClearAll();
        void DrawLine(double x1, double y1, double x2, double y2);
        void DrawRectangle(float x, float y, float height, float width);
        void DrawEllipse(float x, float y, float height, float width);
        void DrawArc(float x, float y, float height, float width, float startAngle, float sweepAngle);
        void DrawString(string text, float x, float y);
        void DrawPolygon(float x, float y, float height, float width);
        void DrawBoundingBox(float x, float y, float height, float width);
    }
}
