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
        public Start(int id, string text, int x, int y, int width, int height, int textBiasX = 0, int textBiasY = 0)
            : base("Start", id, text, x, y, width, height, textBiasX, textBiasY) { }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(X, Y, Width, Height);

            int textX = X + Width / 3 + TextBiasX;
            int textY = Y + Height / 3 + TextBiasY;
            graphics.DrawString(ShapeText, textX, textY);
        }

        public override bool IsPointInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(new Rectangle(X, Y, Width, Height));


            return path.IsVisible(new Point(x, y));
        }

        public override bool IsPointAtText(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            int dotX = (X + Width / 3) + TextBiasX + (10 * ShapeText.Length) / 2 - 2;
            int dotY = (Y + Height / 3) + TextBiasY - 5;
            path.AddRectangle(new RectangleF(dotX, dotY, 8, 8));
            Console.WriteLine("x: " + x + " y: " + y);
            return path.IsVisible(new Point(x, y));
        }

        public override int GetConnectorNumber(int x, int y)
        {
            const int connectorSize = 8;
            const int halfConnectorSize = connectorSize / 2;

            Rectangle topConnector = new Rectangle((X + Width / 2) - halfConnectorSize, Y - halfConnectorSize, connectorSize, connectorSize);
            Rectangle leftConnector = new Rectangle(X - halfConnectorSize, (Y + Height / 2) - halfConnectorSize, connectorSize, connectorSize);
            Rectangle bottomConnector = new Rectangle((X + Width / 2) - halfConnectorSize, (Y + Height) - halfConnectorSize, connectorSize, connectorSize);
            Rectangle rightConnector = new Rectangle((X + Width) - halfConnectorSize, (Y + Height / 2) - halfConnectorSize, connectorSize, connectorSize);

            Point point = new Point(x, y);

            if (topConnector.Contains(point))
            {
                return 1;
            }
            else if (leftConnector.Contains(point))
            {
                return 2;
            }
            else if (bottomConnector.Contains(point))
            {
                return 3;
            }
            else if (rightConnector.Contains(point))
            {
                return 4;
            }
            else
            {
                return -1;
            }
        }
    }
}


