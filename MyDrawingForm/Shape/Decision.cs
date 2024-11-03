using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyDrawingForm
{
    public class Decision : Shape
    {
        public Decision(int id, string text, float x, float y, float height, float width)
            : base("Decision", id, text, x, y, height, width) { }

        public override void Draw(IGraphics graphics)
        {
            Point[] points = new Point[4];
            points[0] = new Point((int)(X + Height / 2), (int)Y);
            points[1] = new Point((int)(X + Height), (int)(Y + Width / 2));
            points[2] = new Point((int)(X + Height / 2), (int)(Y + Width));
            points[3] = new Point((int)X, (int)(Y + Width / 2));
            graphics.DrawPolygon(points);
            graphics.DrawString(ShapeText, X + Height / 3, Y + Width / 3);
        }
    }
}
