using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class Start : Shape
    {
        public Start(int id, string text, float x, float y, float height, float width, float textBiasX = 0, float textBiasY = 0)
            : base("Start", id, text, x, y, height, width, textBiasX, textBiasY) { }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(X, Y, Width, Height);
            graphics.DrawString(ShapeText, (X + Height / 3) + TextBiasX, (Y + Width / 3) + TextBiasY);
        }

        public override bool IsPointInShape(float x, float y)
        {

            GraphicsPath path = new GraphicsPath();

            path.AddEllipse(new Rectangle((int)X, (int)Y, (int)Height, (int)Width));

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
