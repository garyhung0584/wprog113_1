using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class Start : Shape
    {
        public Start(int id, string text, float x, float y, float height, float width)
            : base("Start", id, text, x, y, height, width) { }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(X, Y, Width, Height);
            graphics.DrawString(ShapeText, X + Width / 5, Y + Height / 3);
        }
    }
}
