using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyDrawingForm
{
    public class Decision : Shape
    {
        public Decision(int id, string text, int x, int y, int width, int height, int textBiasX = 0, int textBiasY = 0)
            : base("Decision", id, text, x, y, width, height, textBiasX, textBiasY) { }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawPolygon(X, Y, Width, Height);

            int textX = X + Width / 3 + TextBiasX;
            int textY = Y + Height / 3 + TextBiasY;
            graphics.DrawString(ShapeText, textX, textY);
        }

        public override bool IsPointInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();

            Point[] points = new Point[4];
            points[0] = new Point((X + Width / 2), Y);
            points[1] = new Point((X + Width), (Y + Height / 2));
            points[2] = new Point((X + Width / 2), (Y + Height));
            points[3] = new Point(X, (Y + Height / 2));

            path.AddPolygon(points);

            return path.IsVisible(new Point(x, y));
        }

        public override bool IsPointAtText(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            int dotX = (X + Width / 3) + TextBiasX + (10 * ShapeText.Length) / 2 - 2;
            int dotY = (Y + Height / 3) + TextBiasY - 5;
            path.AddRectangle(new RectangleF(dotX, dotY, 8, 8));

            return path.IsVisible(new Point(x, y));
        }
    }
}
