using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
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
            if (Height < 0 || Width < 0)
            {
                return ;
            }

            graphics.DrawRectangle(X, Y, Width, Height);
            graphics.DrawString(ShapeText, X + Width / 5, Y + Height / 5);
        }

        public override bool IsPointInShape(float x, float y)
        {


            GraphicsPath path = new GraphicsPath();

            path.AddRectangle(new RectangleF(X, Y, Height, Width));

            return path.IsVisible(new Point((int)x, (int)y));
        }
    }
}
