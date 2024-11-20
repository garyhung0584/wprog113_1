using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyDrawingForm
{
    class GraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        private readonly Pen _pen = new Pen(Color.Black, 2);
        private readonly Font _font = new Font("Arial", 12);
        private readonly Brush _brush = new SolidBrush(Color.Black);

        public GraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(_pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        public void DrawRectangle(float x, float y, float height, float width)
        {
            _graphics.DrawRectangle(_pen, x, y, width, height);
        }

        public void DrawEllipse(float x, float y, float height, float width)
        {
            _graphics.DrawEllipse(_pen, x, y, width, height);
        }

        public void DrawArc(float x, float y, float height, float width, float startAngle, float sweepAngle)
        {
            try
            {
                _graphics.DrawArc(_pen, x, y, width, height, startAngle, sweepAngle);
            }
            catch (Exception)
            {
                return;
            }
        }

        public void DrawString(string text, float x, float y)
        {
            _graphics.DrawString(text, _font, _brush, x, y);
        }

        public void DrawPolygon(float x, float y, float height, float width)
        {
            Point[] points = new Point[4];
            points[0] = new Point((int)(x + height / 2), (int)y);
            points[1] = new Point((int)(x + height), (int)(y + width / 2));
            points[2] = new Point((int)(x + height / 2), (int)(y + width));
            points[3] = new Point((int)x, (int)(y + width / 2));

            _graphics.DrawPolygon(_pen, points);
        }

        public void DrawBoundingBox(float x, float y, float height, float width)
        {
            _graphics.DrawRectangle(Pens.Red, x, y, width, height);
        }

    }
}
