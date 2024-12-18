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
        public Terminator(int id, string text, int x, int y, int width, int height, int textBiasX = 0, int textBiasY = 0)
            : base("Terminator", id, text, x, y, width, height, textBiasX, textBiasY) { }

        public override void Draw(IGraphics graphics)
        {
            int width = Width;
            int height = Height;

            if (width < height)
            {
                height = width;
            }

            graphics.DrawArc(X, Y, height, height, 90, 180);
            graphics.DrawArc(X + width - height, Y, height, height, 270, 180);
            graphics.DrawLine(X + height / 2, Y, X + width - (height / 2), Y);
            graphics.DrawLine(X + height / 2, Y + height, X + width - (height / 2), Y + height);

            int textX = X + width / 3 + TextBiasX;
            int textY = Y + height / 3 + TextBiasY;
            graphics.DrawString(ShapeText, textX, textY);
        }

        public override bool IsPointInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(X, Y, Height, Height, 90, 180);
            path.AddLine(X + Height / 2, Y, X + Width - (Height / 2), Y);
            path.AddArc(X + Width - Height, Y, Height, Height, 270, 180);
            path.AddLine(X + Height / 2, Y + Height, X + Width - (Height / 2), Y + Height);
            path.CloseFigure();

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


