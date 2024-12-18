using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

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

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            _graphics.DrawLine(_pen, x1, y1, x2, y2);
        }

        public void DrawRectangle(int x, int y, int width, int height)
        {
            _graphics.DrawRectangle(_pen, x, y, width, height);
        }

        public void DrawEllipse(int x, int y, int width, int height)
        {
            _graphics.DrawEllipse(_pen, x, y, width, height);
        }

        public void DrawArc(int x, int y, int width, int height, int startAngle, int sweepAngle)
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

        public void DrawString(string text, int x, int y)
        {
            _graphics.DrawString(text, _font, _brush, x, y);
        }

        public void DrawPolygon(int x, int y, int width, int height)
        {
            Point[] points = new Point[4];
            points[0] = new Point((x + width / 2), y);
            points[1] = new Point((x + width), (y + height / 2));
            points[2] = new Point((x + width / 2), (y + height));
            points[3] = new Point(x, (y + height / 2));

            _graphics.DrawPolygon(_pen, points);
        }

        public void DrawBoundingBox(int x, int y, int width, int height)
        {
            _graphics.DrawRectangle(Pens.Red, x, y, width, height);
        }

        public void DrawDot(bool isRed, int x, int y, int width, int height)
        {
            if (isRed)
            {
                _graphics.FillRectangle(new SolidBrush(Color.Orange), x, y, width, height);
            }
            else
            {
                _graphics.FillRectangle(new SolidBrush(Color.Black), x, y, width, height);
            }
        }
    }
}
