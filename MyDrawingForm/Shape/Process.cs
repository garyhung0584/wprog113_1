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
        public Process(int id, string text,
            int x, int y, int height, int width, int textBiasX = 0, int textBiasY = 0)
            : base("Process", id, text, x, y, height, width, textBiasX, textBiasY) { }

        public override void Draw(IGraphics graphics)
        {

            graphics.DrawRectangle(X, Y, Width, Height);
            int textX = X + Width / 3 + TextBiasX;
            int textY = Y + Height / 3 + TextBiasY;
            graphics.DrawString(ShapeText, textX, textY);

        }

        public override bool IsPointInShape(int x, int y)
        {


            GraphicsPath path = new GraphicsPath();

            path.AddRectangle(new RectangleF(X, Y, Height, Width));

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
