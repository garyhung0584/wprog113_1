using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class Terminator : Shape
    {
        public Terminator(int id, string text, float x, float y, float height, float width)
            : base("Terminator", id, text, x, y, height, width) { }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawArc(X, Y, Height, Height, 90, 180);
            graphics.DrawArc(X + Width, Y, Height, Height, 270, 180);
            graphics.DrawLine(X + Height / 2, Y, X + Width + Height / 2, Y);
            graphics.DrawLine(X + Height / 2, Y + Height, X + Width + Height / 2, Y + Height);

            graphics.DrawString(ShapeText, X + Width / 2, Y + Height / 2);
        }
    }
}
