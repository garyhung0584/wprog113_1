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
        public Terminator(int id, string text, float x, float y, float height, float width, float textBiasX = 0, float textBiasY = 0)
            : base("Terminator", id, text, x, y, height, width, textBiasX, textBiasY) { }

        public override void Draw(IGraphics graphics)
        {
            float x = X;
            float y = Y;
            float width = Width;
            float height = Height;
            if (width < 0)
            {
                y = y + width;
                width = width * -1;
            }
            if (height < 0)
            {
                x = x + height;
                height = height * -1;
            }
            if (height < width)
            {
                width = height;
            }
            //Left Arc
            graphics.DrawArc(x, y, width, width, 90, 180);
            //Right Arc
            graphics.DrawArc(x + height - (width), y, width, width, 270, 180);
            //Top Line
            graphics.DrawLine(x + width / 2, y, x + height - (width / 2), y);
            //Bottom Line
            graphics.DrawLine(x + width / 2, y + width, x + height - (width / 2), y + width);

            graphics.DrawString(ShapeText, (x + height / 3) + TextBiasX, (y + width / 3) + TextBiasY);
        }

        public override bool IsPointInShape(float x, float y)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(X, Y, Width, Width, 90, 180);
            path.AddLine(X + Width / 2, Y, X + Height - (Width / 2), Y);
            path.AddArc(X + Height - (Width), Y, Width, Width, 270, 180);
            path.AddLine(X + Width / 2, Y + Width, X + Height - (Width / 2), Y + Width);
            //path.AddRectangle(new RectangleF(X + Width / 2, Y, X + Height - (Width / 2), Width));
            path.CloseFigure();

            return path.IsVisible(new Point((int)x, (int)y));
        }
        public override bool IsPointAtText(float x, float y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF((X + Height / 3) + TextBiasX + 27f, ((Y + Width / 3) + TextBiasY) - 3f, 6, 6));
            return path.IsVisible(new Point((int)x, (int)y));
        }
    }
}
