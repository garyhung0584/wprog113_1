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
        public Decision(int id, string text, float x, float y, float height, float width)
            : base("Decision", id, text, x, y, height, width) { }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawPolygon(X, Y, Height, Width);
            graphics.DrawString(ShapeText, X + Height / 3, Y + Width / 3);
        }

        public override bool IsPointInShape(float x, float y)
        {

            GraphicsPath path = new GraphicsPath();

            Point[] points = new Point[4];
            points[0] = new Point((int)(X + Height / 2), (int)Y);
            points[1] = new Point((int)(X + Height), (int)(Y + Width / 2));
            points[2] = new Point((int)(X + Height / 2), (int)(Y + Width));
            points[3] = new Point((int)X, (int)(Y + Width / 2));

            path.AddPolygon(points);
            
            return path.IsVisible(new Point((int)x, (int)y));
        }
    }
}
