using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class Process : Shape
    {
        public Process(int id, string text, float x, float y, float height, float width)
            : base("Process", id, text, x, y, height, width) { }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X, Y, Width, Height);
            graphics.DrawString(ShapeText, X+ Width/5, Y + Height / 5);
        }
    }
}
