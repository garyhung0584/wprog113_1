using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawingForm
{
    public class Terminator : Shape
    {
        public Terminator(int id, string text, float x, float y, float height, float width)
            : base("Terminator", id, text, x, y, height, width) { }

        public override void Draw(IGraphics graphics)
        {
            if (Height < 0 || Width < 0)
            {
                return;
            }
            //Left Arc
            graphics.DrawArc(X, Y, Width, Width, 90, 180);
            //Right Arc
            graphics.DrawArc(X + Height - (Width), Y, Width, Width, 270, 180);
            //Top Line
            graphics.DrawLine(X + Width / 2, Y, X + Height - (Width / 2), Y);
            //Bottom Line
            graphics.DrawLine(X + Width / 2, Y + Width, X + Height - (Width / 2), Y + Width);

            graphics.DrawString(ShapeText, X + Height / 3, Y + Width / 3);
        }

        public override bool IsPointInShape(float x, float y)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(X, Y, Width, Width, 90, 180);
            path.AddLine(X + Width / 2 , Y, X + Height - (Width / 2), Y);
            path.AddArc(X + Height - (Width), Y, Width, Width, 270, 180);
            path.AddLine(X + Width / 2, Y + Width, X + Height - (Width / 2), Y + Width);
            //path.AddRectangle(new RectangleF(X + Width / 2, Y, X + Height - (Width / 2), Width));
            path.CloseFigure();

            return path.IsVisible(new Point((int)x, (int)y));
        }
    }
}
