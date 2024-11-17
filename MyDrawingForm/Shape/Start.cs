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
        public Start(int id, string text, float x, float y, float height, float width)
            : base("Start", id, text, x, y, height, width) { }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(X, Y, Width, Height);
            graphics.DrawString(ShapeText, X + Width / 5, Y + Height / 3);
        }

        public override bool IsPointInShape(float x, float y)
        {

            GraphicsPath path = new GraphicsPath();

            path.AddEllipse(new Rectangle((int)X, (int)Y, (int)Height, (int)Width));

            return path.IsVisible(new Point((int)x, (int)y));
        }
    }
}
